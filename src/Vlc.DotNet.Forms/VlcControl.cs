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

        [Editor(typeof(DirectoryEditor), typeof(UITypeEditor))]
        public DirectoryInfo VlcLibDirectory { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool IsPlaying
        {
            get { return myVlcMediaPlayer.IsPlaying(); }
        }

        public void BeginInit()
        {
        }

        public void EndInit()
        {
            if (DesignMode || myVlcMediaPlayer != null)
                return;
            if (VlcLibDirectory == null && (VlcLibDirectory = OnVlcLibDirectoryNeeded()) == null)
            {
                throw new Exception("'VlcLibDirectory' must be set.");
            }
            myVlcMediaPlayer = new VlcMediaPlayer(VlcLibDirectory);
            myVlcMediaPlayer.VideoHostControlHandle = Handle;
            RegisterEvents();
        }

        public event EventHandler<VlcLibDirectoryNeededEventArgs> VlcLibDirectoryNeeded;

        protected override void Dispose(bool disposing)
        {
            if (myVlcMediaPlayer != null)
            {
                UnregisterEvents();
                if (IsPlaying)
                    Stop();
                var currentMedia = GetCurrentMedia();
                if (currentMedia != null)
                    currentMedia.Dispose();
                myVlcMediaPlayer.Dispose();
                base.Dispose(disposing);
                GC.SuppressFinalize(this);
            }
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

        public void Play()
        {
            EndInit();
            myVlcMediaPlayer.Play();
        }

        public void Play(FileInfo file, params string[] options)
        {
            EndInit();
            myVlcMediaPlayer.SetMedia(file, options);
            Play();
        }

        public void Play(Uri uri, params string[] options)
        {
            EndInit();
            myVlcMediaPlayer.SetMedia(uri, options);
            Play();
        }

        public void Pause()
        {
            EndInit();
            myVlcMediaPlayer.Pause();
        }

        public void Stop()
        {
            EndInit();
            myVlcMediaPlayer.Stop();
        }

        public VlcMedia GetCurrentMedia()
        {
            return myVlcMediaPlayer.GetMedia();
        }

        public float Position
        {
            get { return myVlcMediaPlayer.Position; }
            set { myVlcMediaPlayer.Position = value; }
        }

        public long Length
        {
            get { return myVlcMediaPlayer.Length; }
        }

        public long Time
        {
            get { return myVlcMediaPlayer.Time; }
            set { myVlcMediaPlayer.Time = value; }
        }

        public IChapterManagement Chapter
        {
            get
            {
                return myVlcMediaPlayer.Chapters;
            }
        }

        public float Rate
        {
            get { return myVlcMediaPlayer.Rate; }
            set { myVlcMediaPlayer.Rate = value; }
        }

        public MediaStates State
        {
            get { return myVlcMediaPlayer.State; }
        }

        public ISubTitlesManagement SubTitles
        {
            get
            {
                return myVlcMediaPlayer.SubTitles;
            }
        }

        public IVideoManagement Video
        {
            get
            {
                return myVlcMediaPlayer.Video;
            }
        }
    }
}