using System;
using System.Collections.Generic;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    internal class AudioOutputsManagement : IAudioOutputsManagement
    {
        private readonly VlcManager myManager;
        private readonly VlcMediaPlayerInstance myMediaPlayerInstance;

        internal AudioOutputsManagement(VlcManager manager, VlcMediaPlayerInstance mediaPlayerInstance)
        {
            myManager = manager;
            myMediaPlayerInstance = mediaPlayerInstance;
        }

        public IEnumerable<AudioOutputDescription> All
        {
            get
            {
                var module = myManager.GetAudioOutputsDescriptions();
                var result = AudioOutputDescription.GetSubOutputDescription(module, myManager, myMediaPlayerInstance);
                myManager.ReleaseAudioOutputDescription(module);
                return result;
            }
        }

        public int Count
        {
            get { return new List<AudioOutputDescription>(All).Count; }
        }

        public AudioOutputDescription Current
        {
            get
            {
                throw new NotImplementedException("Not implemented in LibVlc.");
            }
            set { myManager.SetAudioOutput(value.Name); }
        }
    }
}
