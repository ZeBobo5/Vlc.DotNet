using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed class AudioOutputDevice
    {
        private VlcManager myManager;
        private VlcMediaPlayerInstance myMediaPlayerInstance;
        private AudioOutputDescription myAudioOutputDescription;

        public int Id { get; private set; }

        public string Name
        {
            get
            {
                return myManager.GetAudioOutputDeviceName(myAudioOutputDescription.Name, Id);
            }
        }

        public string LongName
        {
            get
            {
                return myManager.GetAudioOutputDeviceLongName(myAudioOutputDescription.Name, Id);
            }
        }

        internal AudioOutputDevice(VlcManager manager, VlcMediaPlayerInstance mediaPlayerInstance, AudioOutputDescription audioDescription, int id)
        {
            myManager = manager;
            myMediaPlayerInstance = mediaPlayerInstance;
            myAudioOutputDescription = audioDescription;
            Id = id;
        }

        public void SetAsCurrent()
        {
            myManager.SetAudioOutputDevice(myMediaPlayerInstance, myAudioOutputDescription.Name, Name);
        }
    }
}
