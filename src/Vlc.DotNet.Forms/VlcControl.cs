using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;
using Vlc.DotNet.Forms.TypeEditors;

namespace Vlc.DotNet.Forms
{
    public partial class VlcControl : Control, ISupportInitialize
    {
        private VlcMediaPlayer myVlcMediaPlayer;

        /// <summary>
        /// Gets the media player.
        /// It can be useful in order to achieve lower-level operations that are not available in the control.
        /// </summary>
        public VlcMediaPlayer VlcMediaPlayer => this.myVlcMediaPlayer;

        #region VlcControl Init

        public VlcControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Init Component behaviour
            BackColor = System.Drawing.Color.Black;
        }

        private string[] _vlcMediaPlayerOptions = null;

        [Category("Media Player")]
        public string[] VlcMediaplayerOptions
        {
            get { return this._vlcMediaPlayerOptions; }
            set
            {
                if (!(myVlcMediaPlayer is null))
                {
                    throw new InvalidOperationException("Cannot modify VlcMediaplayerOptions if Media player has already been initialized. Modify VlcMediaplayerOptions before calling EndInit.");
                }

                this._vlcMediaPlayerOptions = value;
            }
        }

        private DirectoryInfo _vlcLibDirectory = null;
        [Category("Media Player")]
        [Editor(typeof(DirectoryEditor), typeof(UITypeEditor))]
        public DirectoryInfo VlcLibDirectory {
            get { return this._vlcLibDirectory; }
            set
            {
                if (!(myVlcMediaPlayer is null))
                {
                    throw new InvalidOperationException("Cannot modify VlcLibDirectory if Media player has already been initialized. Modify VlcLibDirectory before calling EndInit.");
                }

                this._vlcLibDirectory = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool IsPlaying
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.IsPlaying();
                }
                else
                {
                    return false;
                }
            }
        }

        public void BeginInit()
        {
            // not used yet
        }

        public void EndInit()
        {
            if (IsInDesignMode || myVlcMediaPlayer != null)
                return;
            if (_vlcLibDirectory == null && (_vlcLibDirectory = OnVlcLibDirectoryNeeded()) == null)
            {
                throw new Exception("'VlcLibDirectory' must be set.");
            }

            if (VlcMediaplayerOptions == null)
            {
                myVlcMediaPlayer = new VlcMediaPlayer(VlcLibDirectory);
            }
            else
            {
                myVlcMediaPlayer = new VlcMediaPlayer(VlcLibDirectory, VlcMediaplayerOptions);
            }

            if (this.log != null)
            {
                this.RegisterLogging();
            }
            myVlcMediaPlayer.VideoHostControlHandle = Handle;

            RegisterEvents();
        }

        private bool loggingRegistered = false;

        /// <summary>
        /// Connects (only the first time) the events from <see cref="myVlcMediaPlayer"/> to the event handlers registered on this instance
        /// </summary>
        private void RegisterLogging()
        {
            if (this.loggingRegistered)
                return;
            this.myVlcMediaPlayer.Log += this.OnLogInternal;
            this.loggingRegistered = true;
        }

        // work around https://stackoverflow.com/questions/34664/designmode-with-nested-controls/2693338#2693338
        private bool IsInDesignMode
        {
            get
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    return true;

                Control ctrl = this;
                while (ctrl != null)
                {
                    if ((ctrl.Site != null) && ctrl.Site.DesignMode)
                        return true;
                    ctrl = ctrl.Parent;
                }
                return false;
            }
        }

        public event EventHandler<VlcLibDirectoryNeededEventArgs> VlcLibDirectoryNeeded;

        bool disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (myVlcMediaPlayer != null)
                    {
                        UnregisterEvents();
                        myVlcMediaPlayer.Dispose();
                    }
                    myVlcMediaPlayer = null;
                }
                disposed = true;
            }
            base.Dispose(disposing);
        }

        public DirectoryInfo OnVlcLibDirectoryNeeded()
        {
            var del = VlcLibDirectoryNeeded;
            if (del != null)
            {
                var args = new VlcLibDirectoryNeededEventArgs();
                del(this, args);
                return args.VlcLibDirectory;
            }
            return null;
        }
        #endregion

        #region VlcControl Functions & Properties

        public void Play()
        {
            myVlcMediaPlayer?.Play();
        }

        public void Play(FileInfo file, params string[] options)
        {
            myVlcMediaPlayer?.Play(file, options);
        }

        public void Play(Uri uri, params string[] options)
        {
            myVlcMediaPlayer?.Play(uri, options);
        }

        public void Play(string mrl, params string[] options)
        {
            myVlcMediaPlayer?.Play(mrl, options);
        }

        public void Play(Stream stream, params string[] options)
        {
            myVlcMediaPlayer?.Play(stream, options);
        }

        /// <summary>
        /// Toggle pause (no effect if there is no media) 
        /// </summary>
        public void Pause()
        {
            myVlcMediaPlayer?.Pause();
        }

        /// <summary>
        /// Pause or resume (no effect if there is no media) 
        /// </summary>
        /// <param name="doPause">If set to <c>true</c>, pauses the media, resumes if <c>false</c></param>
        public void SetPause(bool doPause)
        {
            myVlcMediaPlayer?.SetPause(doPause);
        }

        public void Stop()
        {
            //EndInit();
            if (myVlcMediaPlayer != null)
            {
                myVlcMediaPlayer.Stop();
            }

        }

        public VlcMedia GetCurrentMedia()
        {
            //EndInit();
            if (myVlcMediaPlayer != null)
            {
                return myVlcMediaPlayer.GetMedia();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Takes a snapshot of the currently playing video and saves it to the given file
        /// </summary>
        /// <param name="fileName">The name of the file to be written</param>
        public bool TakeSnapshot(string fileName)
        {
            return this.TakeSnapshot(fileName, 0, 0);
        }

        /// <summary>
        /// Takes a snapshot of the currently playing video and saves it to the given file
        /// </summary>
        /// <remarks>If width AND height is 0, original size is used. If width XOR height is 0, original aspect-ratio is preserved.</remarks>
        /// <param name="fileName">The name of the file to be written</param>
        /// <param name="width">The width of the snapshot (0 means auto)</param>
        /// <param name="height">The height of the snapshot (0 means auto)</param>
        public bool TakeSnapshot(string fileName, uint width, uint height)
        {
            return this.TakeSnapshot(new FileInfo(fileName), width, height);
        }


        /// <summary>
        /// Takes a snapshot of the currently playing video and saves it to the given file
        /// </summary>
        /// <param name="file">The file to be written</param>
        public bool TakeSnapshot(FileInfo file)
        {
            return this.TakeSnapshot(file, 0, 0);
        }


        /// <summary>
        /// Takes a snapshot of the currently playing video and saves it to the given file
        /// </summary>
        /// <remarks>If width AND height is 0, original size is used. If width XOR height is 0, original aspect-ratio is preserved.</remarks>
        /// <param name="file">The file to be written</param>
        /// <param name="width">The width of the snapshot (0 means auto)</param>
        /// <param name="height">The height of the snapshot (0 means auto)</param>
        public bool TakeSnapshot(FileInfo file, uint width, uint height)
        {
            return this.myVlcMediaPlayer.TakeSnapshot(file, width, height);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public float Position
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Position;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (myVlcMediaPlayer != null)
                {
                    myVlcMediaPlayer.Position = value;
                }

            }
        }

        [Browsable(false)]
        public IChapterManagement Chapter
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Chapters;
                }
                else
                {
                    return null;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public float Rate
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Rate;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (myVlcMediaPlayer != null)
                {
                    myVlcMediaPlayer.Rate = value;
                }
            }
        }

        [Browsable(false)]
        public MediaStates State
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.State;
                }
                else
                {
                    return MediaStates.NothingSpecial;
                }
            }
        }

        [Browsable(false)]
        public ISubTitlesManagement SubTitles
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.SubTitles;
                }
                else
                {
                    return null;
                }

            }
        }

        [Browsable(false)]
        public IVideoManagement Video
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Video;
                }
                else
                {
                    return null;
                }
            }
        }

        [Browsable(false)]
        public IAudioManagement Audio
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Audio;
                }
                else
                {
                    return null;
                }
            }
        }

        [Browsable(false)]
        public long Length
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Length;
                }
                else
                {
                    return -1;
                }

            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public long Time
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Time;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (myVlcMediaPlayer != null)
                {
                    myVlcMediaPlayer.Time = value;
                }
            }
        }

        [Browsable(false)]
        public int Spu
        {
            get
            {
                if (myVlcMediaPlayer != null)
                {
                    return myVlcMediaPlayer.Spu;
                }
                return -1;
            }
            set
            {
                if (myVlcMediaPlayer != null)
                {
                    myVlcMediaPlayer.Spu = value;
                }
            }
        }

        public void SetMedia(FileInfo file, params string[] options)
        {
            //EndInit();
            myVlcMediaPlayer.SetMedia(file, options);
        }

        public void SetMedia(Uri file, params string[] options)
        {
            //EndInit();
            myVlcMediaPlayer.SetMedia(file, options);
        }
        
        public void SetMedia(string mrl, params string[] options)
        {
            //EndInit();
            myVlcMediaPlayer.SetMedia(mrl, options);
        }

        public void SetMedia(Stream stream, params string[] options)
        {
            //EndInit();
            myVlcMediaPlayer.SetMedia(stream, options);
        }

        public void ResetMedia()
        {
            myVlcMediaPlayer.ResetMedia();
        }
        #endregion
    }
}
