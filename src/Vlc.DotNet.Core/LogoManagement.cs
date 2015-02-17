using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    internal class LogoManagement : ILogoManagement
    {
        private readonly VlcManager myManager;
        private readonly VlcMediaPlayerInstance myMediaPlayer;

        public LogoManagement(VlcManager manager, VlcMediaPlayerInstance mediaPlayerInstance)
        {
            myManager = manager;
            myMediaPlayer = mediaPlayerInstance;
        }

        public bool Enabled
        {
            get { return myManager.GetVideoLogoEnabled(myMediaPlayer); }
            set { myManager.SetVideoLogoEnabled(myMediaPlayer, value); }
        }

        public string File
        {
            set { myManager.SetVideoLogoFile(myMediaPlayer, value); }
        }

        public int X
        {
            get { return myManager.GetVideoLogoX(myMediaPlayer); }
            set { myManager.SetVideoLogoX(myMediaPlayer, value); }
        }

        public int Y
        {
            get { return myManager.GetVideoLogoY(myMediaPlayer); }
            set { myManager.SetVideoLogoY(myMediaPlayer, value); }
        }

        public int Delay
        {
            get { return myManager.GetVideoLogoDelay(myMediaPlayer); }
            set { myManager.SetVideoLogoDelay(myMediaPlayer, value); }
        }

        public int Repeat
        {
            get { return myManager.GetVideoLogoRepeat(myMediaPlayer); }
            set { myManager.SetVideoLogoRepeat(myMediaPlayer, value); }
        }

        public int Opacity
        {
            get { return myManager.GetVideoLogoOpacity(myMediaPlayer); }
            set { myManager.SetVideoLogoOpacity(myMediaPlayer, value); }
        }

        public int Position
        {
            get { return myManager.GetVideoLogoPosition(myMediaPlayer); }
            set { myManager.SetVideoLogoPosition(myMediaPlayer, value); }
        }
    }
}
