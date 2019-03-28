using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
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
#if NET20
                var results = myManager.GetAudioOutputsDescriptions();
                var resultsList = new List<AudioOutputDescription>(results.Count);
                foreach(var x in results)
                {
                    resultsList.Add(new AudioOutputDescription(x.Name, x.Description, this.myManager));
                }

                return resultsList;
#else
                return myManager.GetAudioOutputsDescriptions().Select(x => new AudioOutputDescription(x.Name, x.Description, this.myManager));
#endif
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
