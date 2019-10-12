using System;
using System.Collections.Generic;
using System.Linq;
using Vlc.DotNet.Core.Interops;

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
                return myManager.GetAudioOutputsDescriptions().Select(x => new AudioOutputDescription(x.Name, x.Description, this.myManager));
            }
        }

        public int Count => myManager.GetAudioOutputsDescriptions().Count;

        public AudioOutputDescription Current
        {
            get
            {
                throw new NotSupportedException("Not implemented in LibVlc.");
            }
            set { myManager.SetAudioOutput(myMediaPlayerInstance, value.Name); }
        }
    }
}
