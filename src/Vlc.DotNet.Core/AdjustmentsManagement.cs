using System;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    internal class AdjustmentsManagement : IAdjustmentsManagement
    {
        private readonly VlcManager myManager;
        private readonly VlcMediaPlayerInstance myMediaPlayer;

        public AdjustmentsManagement(VlcManager manager, VlcMediaPlayerInstance mediaPlayerInstance)
        {
            myManager = manager;
            myMediaPlayer = mediaPlayerInstance;
        }

        public bool Enabled
        {
            get { return myManager.GetVideoAdjustEnabled(myMediaPlayer); }
            set { myManager.SetVideoAdjustEnabled(myMediaPlayer, value); }
        }

        public float Contrast
        {
            get { return myManager.GetVideoAdjustContrast(myMediaPlayer); }
            set { myManager.SetVideoAdjustContrast(myMediaPlayer, value); }
        }

        public float Brightness
        {
            get { return myManager.GetVideoAdjustBrightness(myMediaPlayer); }
            set { myManager.SetVideoAdjustBrightness(myMediaPlayer, value); }
        }

        public float Hue
        {
            get { return myManager.GetVideoAdjustHue(myMediaPlayer); }
            set { myManager.SetVideoAdjustHue(myMediaPlayer, value); }
        }

        public float Saturation
        {
            get { return myManager.GetVideoAdjustSaturation(myMediaPlayer); }
            set { myManager.SetVideoAdjustSaturation(myMediaPlayer, value); }
        }

        public float Gamma
        {
            get { return myManager.GetVideoAdjustGamma(myMediaPlayer); }
            set { myManager.SetVideoAdjustGamma(myMediaPlayer, value); }
        }
    }
}
