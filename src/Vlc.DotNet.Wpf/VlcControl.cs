
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
    using System.Windows.Controls;
    using System.Windows.Interop;
    using System.Windows.Data;


    public class VlcControl : UserControl, IDisposable
    {
        private Viewbox viewBox;
        private readonly Image videoContent = new Image();
        private Size currentSize = new Size(1, 1);

#if NET45
        private MemoryMappedFile memoryMappedFile;
        private MemoryMappedViewAccessor memoryMappedView;
#else
        private IntPtr memoryMappedFile;
        private IntPtr memoryMappedView;
#endif

        public InteropBitmap VideoSource
        {
            get { return (InteropBitmap)this.GetValue(VideoSourceProperty); }
            private set { this.SetValue(VideoSourcePropertyKey, value); }
        }

        private static readonly DependencyPropertyKey VideoSourcePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(VideoSource), typeof(InteropBitmap), typeof(VlcControl),
                new PropertyMetadata(null));

        public static readonly DependencyProperty VideoSourceProperty = VideoSourcePropertyKey.DependencyProperty;

        public VlcControl()
        {
            this.viewBox = new Viewbox()
            {
                Child = this.videoContent,
                Stretch = Stretch.Uniform
            };

            this.Content = this.viewBox;
            this.Background = Brushes.Black;
            // Binds the VideoSource to the Image.Source property
            this.videoContent.SetBinding(Image.SourceProperty, new Binding(nameof(VideoSource)) {Source = this});
        }

        public VlcMediaPlayer MediaPlayer { get; private set; }

        public void CreatePlayer(DirectoryInfo vlcLibDirectory)
        {
            var directoryInfo = vlcLibDirectory ?? throw new ArgumentNullException(nameof(vlcLibDirectory));

            this.MediaPlayer = new VlcMediaPlayer(directoryInfo);

            this.MediaPlayer.SetVideoFormatCallbacks(this.VideoFormat, this.CleanupVideo);
            this.MediaPlayer.SetVideoCallbacks(LockVideo, null, DisplayVideo, IntPtr.Zero);
        }

#region Vlc video callbacks
        private uint VideoFormat(out IntPtr userdata, ref UInt32 chroma, ref uint width, ref uint height, ref uint pitches, ref uint lines)
        {
            var pixelFormat = PixelFormats.Bgr32;
            chroma = BitConverter.ToUInt32(new[] {(byte) 'R', (byte) 'V', (byte) '3', (byte) '2'}, 0);
            pitches = (uint)(width*pixelFormat.BitsPerPixel) / 8;
            lines = (uint)this.currentSize.Height;

            var size = width * height * (uint)pixelFormat.BitsPerPixel / 8;
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

            Dispatcher.Invoke((Action)(() =>
            {
                this.VideoSource = (InteropBitmap)Imaging.CreateBitmapSourceFromMemorySection(handle, (int) args.width, (int) args.height, args.pixelFormat, (int) args.pitches, 0);
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

        private void CleanupVideo(ref IntPtr userdata)
        {
            if (!disposedValue)
            {
                Dispatcher.Invoke((Action)this.RemoveVideo);
            }
        }

        private IntPtr LockVideo(IntPtr userdata, IntPtr planes)
        {
            Marshal.WriteIntPtr(planes, userdata);
            return userdata;
        }

        private void DisplayVideo(IntPtr userdata, IntPtr picture)
        {
            this.Dispatcher.BeginInvoke((Action) (() => this.VideoSource?.Invalidate()));
        }
        #endregion

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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
                this.MediaPlayer?.Dispose();
                this.MediaPlayer = null;
                Dispatcher.Invoke((Action)this.RemoveVideo);
            }
        }

        ~VlcControl() {
           Dispose(false);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion
    }
}
