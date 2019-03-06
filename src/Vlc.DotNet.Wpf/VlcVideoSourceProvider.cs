using System.Linq;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Wpf
{
    using System;
    using System.IO;
#if NET45
    using System.IO.MemoryMappedFiles;
#endif
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Media;
    using Vlc.DotNet.Core;
    using System.Windows.Interop;
    using System.ComponentModel;
    using System.Windows.Threading;

    /// <summary>
    /// The class that can provide a Wpf Image Source to display the video.
    /// </summary>
    public class VlcVideoSourceProvider : INotifyPropertyChanged, IDisposable
    {
#if NET45
        /// <summary>
        /// The memory mapped file that contains the picture data
        /// </summary>
        private MemoryMappedFile memoryMappedFile;

        /// <summary>
        /// The view that contains the pointer to the buffer that contains the picture data
        /// </summary>
        private MemoryMappedViewAccessor memoryMappedView;
#else
        /// <summary>
        /// The memory mapped file handle that contains the picture data
        /// </summary>
        private IntPtr memoryMappedFile;

        /// <summary>
        /// The pointer to the buffer that contains the picture data
        /// </summary>
        private IntPtr memoryMappedView;
#endif
        private bool isAlphaChannelEnabled;
        private bool playerCreated;

        private ImageSource videoSource;

        private Dispatcher dispatcher;

        public VlcVideoSourceProvider(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        /// <summary>
        /// The Image source that represents the video.
        /// </summary>
        public ImageSource VideoSource
        {
            get
            {
                return this.videoSource;
            }

            private set
            {
                if (!Object.ReferenceEquals(this.videoSource, value))
                {
                    this.videoSource = value;
                    this.OnPropertyChanged(nameof(VideoSource));
                }
            }
        }

        /// <summary>
        /// The media player instance. You must call <see cref="CreatePlayer"/> before using this.
        /// </summary>
        public VlcMediaPlayer MediaPlayer { get; private set; }

        /// <summary>
        /// Defines if <see cref="VideoSource"/> pixel format is <see cref="PixelFormats.Bgr32"/> or <see cref="PixelFormats.Bgra32"/>
        /// </summary>
        public bool IsAlphaChannelEnabled { get
            {
                return this.isAlphaChannelEnabled;
            }

            set
            {
                if (!playerCreated)
                    this.isAlphaChannelEnabled = value;
                else
                    throw new InvalidOperationException("IsAlphaChannelEnabled property should be changed only before CreatePlayer method is called.");
            }
        }

        /// <summary>
        /// Creates the player. This method must be called before using <see cref="MediaPlayer"/>
        /// </summary>
        /// <param name="vlcLibDirectory">The directory where to find the vlc library</param>
        /// <param name="vlcMediaPlayerOptions">The initialization options to be given to libvlc</param>
        public void CreatePlayer(DirectoryInfo vlcLibDirectory, params string[] vlcMediaPlayerOptions)
        {
            var directoryInfo = vlcLibDirectory ?? throw new ArgumentNullException(nameof(vlcLibDirectory));

            this.MediaPlayer = new VlcMediaPlayer(directoryInfo, vlcMediaPlayerOptions);

            this.MediaPlayer.SetVideoFormatCallbacks(this.VideoFormat, this.CleanupVideo);
            this.MediaPlayer.SetVideoCallbacks(LockVideo, null, DisplayVideo, IntPtr.Zero);

            playerCreated = true;
        }

        /// <summary>
        /// Aligns dimension to the next multiple of mod
        /// </summary>
        /// <param name="dimension">The dimension to be aligned</param>
        /// <param name="mod">The modulus</param>
        /// <returns>The aligned dimension</returns>
        private uint GetAlignedDimension(uint dimension, uint mod)
        {
            var modResult = dimension % mod;
            if (modResult == 0)
            {
                return dimension;
            }

            return dimension + mod - (dimension % mod);
        }

        #region Vlc video callbacks
        /// <summary>
        /// Called by vlc when the video format is needed. This method allocats the picture buffers for vlc and tells it to set the chroma to RV32
        /// </summary>
        /// <param name="userdata">The user data that will be given to the <see cref="LockVideo"/> callback. It contains the pointer to the buffer</param>
        /// <param name="chroma">The chroma</param>
        /// <param name="width">The visible width</param>
        /// <param name="height">The visible height</param>
        /// <param name="pitches">The buffer width</param>
        /// <param name="lines">The buffer height</param>
        /// <returns>The number of buffers allocated</returns>
        private uint VideoFormat(out IntPtr userdata, IntPtr chroma, ref uint width, ref uint height, ref uint pitches, ref uint lines)
        {
            var pixelFormat = IsAlphaChannelEnabled ? PixelFormats.Bgra32 : PixelFormats.Bgr32;
            FourCCConverter.ToFourCC("RV32", chroma);
            
            //Correct video width and height according to TrackInfo
            var md = MediaPlayer.GetMedia();
            foreach (MediaTrack track in md.Tracks)
            {
                if (track.Type == MediaTrackTypes.Video)
                {
                    var trackInfo = (VideoTrack)track.TrackInfo;
                    if (trackInfo.Width > 0 && trackInfo.Height > 0)
                    {
                        width = trackInfo.Width;
                        height = trackInfo.Height;
                        if (trackInfo.SarDen != 0)
                        {
                            width = width * trackInfo.SarNum / trackInfo.SarDen;
                        }
                    }

                    break;
                }
            }

            pitches = this.GetAlignedDimension((uint)(width * pixelFormat.BitsPerPixel) / 8, 32);
            lines = this.GetAlignedDimension(height, 32);

            var size = pitches * lines;
#if NET45
            this.memoryMappedFile = MemoryMappedFile.CreateNew(null, size);
            var handle = this.memoryMappedFile.SafeMemoryMappedFileHandle.DangerousGetHandle();
#else
            this.memoryMappedFile = Win32Interop.CreateFileMapping(new IntPtr(-1), IntPtr.Zero,
                Win32Interop.PageAccess.ReadWrite, 0, (int)size, null);
            var handle = this.memoryMappedFile;
#endif
            var args = new
            {
                width = width,
                height = height,
                pixelFormat = pixelFormat,
                pitches = pitches
            };

            this.dispatcher.Invoke((Action)(() =>
            {
                this.VideoSource = (InteropBitmap)Imaging.CreateBitmapSourceFromMemorySection(handle,
                    (int)args.width, (int)args.height, args.pixelFormat, (int)args.pitches, 0);
            }));

#if NET45
            this.memoryMappedView = this.memoryMappedFile.CreateViewAccessor();
            var viewHandle = this.memoryMappedView.SafeMemoryMappedViewHandle.DangerousGetHandle();
#else
            this.memoryMappedView = Win32Interop.MapViewOfFile(this.memoryMappedFile, Win32Interop.FileMapAccess.AllAccess, 0, 0, size);
            var viewHandle = this.memoryMappedView;
#endif
            userdata = viewHandle;
            return 1;
        }

        /// <summary>
        /// Called by Vlc when it requires a cleanup
        /// </summary>
        /// <param name="userdata">The parameter is not used</param>
        private void CleanupVideo(ref IntPtr userdata)
        {
            // This callback may be called by Dispose in the Dispatcher thread, in which case it deadlocks if we call RemoveVideo again in the same thread.
            if (!disposedValue)
            {
                this.dispatcher.Invoke((Action)this.RemoveVideo);
            }
        }

        /// <summary>
        /// Called by libvlc when it wants to acquire a buffer where to write
        /// </summary>
        /// <param name="userdata">The pointer to the buffer (the out parameter of the <see cref="VideoFormat"/> callback)</param>
        /// <param name="planes">The pointer to the planes array. Since only one plane has been allocated, the array has only one value to be allocated.</param>
        /// <returns>The pointer that is passed to the other callbacks as a picture identifier, this is not used</returns>
        private IntPtr LockVideo(IntPtr userdata, IntPtr planes)
        {
            Marshal.WriteIntPtr(planes, userdata);
            return userdata;
        }

        /// <summary>
        /// Called by libvlc when the picture has to be displayed.
        /// </summary>
        /// <param name="userdata">The pointer to the buffer (the out parameter of the <see cref="VideoFormat"/> callback)</param>
        /// <param name="picture">The pointer returned by the <see cref="LockVideo"/> callback. This is not used.</param>
        private void DisplayVideo(IntPtr userdata, IntPtr picture)
        {
            // Invalidates the bitmap
            this.dispatcher.BeginInvoke((Action)(() =>
            {
                (this.VideoSource as InteropBitmap)?.Invalidate();
            }));
        }
        #endregion

        /// <summary>
        /// Removes the video (must be called from the Dispatcher thread)
        /// </summary>
        private void RemoveVideo()
        {
            this.VideoSource = null;

#if NET45
            this.memoryMappedView?.Dispose();
            this.memoryMappedView = null;
            this.memoryMappedFile?.Dispose();
            this.memoryMappedFile = null;
#else
            if (this.memoryMappedFile != IntPtr.Zero)
            {
                Win32Interop.UnmapViewOfFile(this.memoryMappedView);
                this.memoryMappedView = IntPtr.Zero;
                Win32Interop.CloseHandle(this.memoryMappedFile);
                this.memoryMappedFile = IntPtr.Zero;
            }
#endif
        }

        #region IDisposable Support
        private bool disposedValue = false;

        /// <summary>
        /// Disposes the control.
        /// </summary>
        /// <param name="disposing">The parameter is not used.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
                this.MediaPlayer?.Dispose();
                this.MediaPlayer = null;
                this.dispatcher.BeginInvoke((Action)this.RemoveVideo);
            }
        }

        /// <summary>
        /// The destructor
        /// </summary>
        ~VlcVideoSourceProvider()
        {
            Dispose(false);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
