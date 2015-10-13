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

        public string[] VlcMediaplayerOptions { get; set; }

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
            if (IsInDesignMode() || myVlcMediaPlayer != null)
                return;
            if (VlcLibDirectory == null && (VlcLibDirectory = OnVlcLibDirectoryNeeded()) == null)
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
            myVlcMediaPlayer.VideoHostControlHandle = Handle;
            RegisterEvents();
        }

        // work around http://stackoverflow.com/questions/34664/designmode-with-controls/708594
        private static bool IsInDesignMode()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location.Contains("VisualStudio");
        }

        public event EventHandler<VlcLibDirectoryNeededEventArgs> VlcLibDirectoryNeeded;

        protected override void Dispose(bool disposing)
        {
            if (myVlcMediaPlayer != null)
            {
                UnregisterEvents();
                if (IsPlaying)
                    Stop();
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
            EndInit();
            return myVlcMediaPlayer.GetMedia();
        }
        
        public void TakeSnapshot(string fileName) 
        {
            FileInfo fileInfo = new FileInfo(fileName);
            myVlcMediaPlayer.TakeSnapshot(fileInfo);
        }

        public float Position
        {
            get { return myVlcMediaPlayer.Position; }
            set { myVlcMediaPlayer.Position = value; }
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

        public IAudioManagement Audio
        {
            get
            {
                return myVlcMediaPlayer.Audio;
            }
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

        public void SetMedia(FileInfo file, params string[] options)
        {
            EndInit();
            myVlcMediaPlayer.SetMedia(file, options);
        }

        public void SetMedia(Uri file, params string[] options)
        {
            EndInit();
            myVlcMediaPlayer.SetMedia(file, options);
        }
    }
}
