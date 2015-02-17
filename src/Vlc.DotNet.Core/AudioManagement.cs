using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    internal class AudioManagement : IAudioManagement
    {
        private readonly VlcManager myManager;
        private readonly VlcMediaPlayerInstance myMediaPlayer;

        internal AudioManagement(VlcManager manager, VlcMediaPlayerInstance mediaPlayerInstance)
        {
            myManager = manager;
            myMediaPlayer = mediaPlayerInstance;
            Outputs = new AudioOutputsManagement(manager, mediaPlayerInstance);
            Tracks = new AudioTracksManagement(manager, mediaPlayerInstance);
        }

        public IAudioOutputsManagement Outputs { get; private set; }

        public bool IsMute
        {
            get { return myManager.IsMute(myMediaPlayer); }
            set { myManager.SetMute(myMediaPlayer, value); }
        }

        public void ToggleMute()
        {
            myManager.ToggleMute(myMediaPlayer);
        }

        public int Volume
        {
            get { return myManager.GetVolume(myMediaPlayer); }
            set { myManager.SetVolume(myMediaPlayer, value); }
        }

        public ITracksManagement Tracks { get; private set; }

        public int Channel
        {
            get { return myManager.GetAudioChannel(myMediaPlayer); }
            set { myManager.SetAudioChannel(myMediaPlayer, value); }
        }

        public long Delay
        {
            get { return myManager.GetAudioDelay(myMediaPlayer); }
            set { myManager.SetAudioDelay(myMediaPlayer, value); }
        }
    }
}
