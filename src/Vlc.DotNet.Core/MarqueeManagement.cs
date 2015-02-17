using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    internal class MarqueeManagement : IMarqueeManagement
    {
        private readonly VlcManager myManager;
        private readonly VlcMediaPlayerInstance myMediaPlayer;

        public MarqueeManagement(VlcManager manager, VlcMediaPlayerInstance mediaPlayerInstance)
        {
            myManager = manager;
            myMediaPlayer = mediaPlayerInstance;
        }

        public bool Enabled
        {
            get { return myManager.GetVideoMarqueeEnabled(myMediaPlayer); }
            set { myManager.SetVideoMarqueeEnabled(myMediaPlayer, value); }
        }

        public string Text
        {
            get { return myManager.GetVideoMarqueeText(myMediaPlayer); }
            set { myManager.SetVideoMarqueeText(myMediaPlayer, value); }
        }

        public int Color
        {
            get { return myManager.GetVideoMarqueeColor(myMediaPlayer); }
            set { myManager.SetVideoMarqueeColor(myMediaPlayer, value); }
        }

        public int Opacity
        {
            get { return myManager.GetVideoMarqueeOpacity(myMediaPlayer); }
            set { myManager.SetVideoMarqueeOpacity(myMediaPlayer, value); }
        }

        public int Position
        {
            get { return myManager.GetVideoMarqueePosition(myMediaPlayer); }
            set { myManager.SetVideoMarqueePosition(myMediaPlayer, value); }
        }

        public int Refresh
        {
            get { return myManager.GetVideoMarqueeRefresh(myMediaPlayer); }
            set { myManager.SetVideoMarqueeRefresh(myMediaPlayer, value); }
        }

        public int Size
        {
            get { return myManager.GetVideoMarqueeSize(myMediaPlayer); }
            set { myManager.SetVideoMarqueeSize(myMediaPlayer, value); }
        }

        public int Timeout
        {
            get { return myManager.GetVideoMarqueeTimeout(myMediaPlayer); }
            set { myManager.SetVideoMarqueeTimeout(myMediaPlayer, value); }
        }

        public int X
        {
            get { return myManager.GetVideoMarqueeX(myMediaPlayer); }
            set { myManager.SetVideoMarqueeX(myMediaPlayer, value); }
        }

        public int Y
        {
            get { return myManager.GetVideoMarqueeY(myMediaPlayer); }
            set { myManager.SetVideoMarqueeY(myMediaPlayer, value); }
        }
    }
}
