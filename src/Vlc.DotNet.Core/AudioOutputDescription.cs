using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed class AudioOutputDescription
    {
        private VlcManager myManager;
        private VlcMediaPlayerInstance myMediaPlayerInstance;

        public string Name { get; private set; }
        public string Description { get; private set; }

        internal AudioOutputDescription(string name, string description, VlcManager manager, VlcMediaPlayerInstance mediaPlayerInstance)
        {
            Name = name;
            Description = description;
            myManager = manager;
            myMediaPlayerInstance = mediaPlayerInstance;
            Devices = new AudioOutputDevices(this, manager, myMediaPlayerInstance);
        }

        internal static List<AudioOutputDescription> GetSubOutputDescription(AudioOutputDescriptionStructure module, VlcManager manager, VlcMediaPlayerInstance mediaPlayerInstance)
        {
            var result = new List<AudioOutputDescription>();
            result.Add(new AudioOutputDescription(module.Name, module.Description, manager, mediaPlayerInstance));
            if (module.NextAudioOutputDescription != IntPtr.Zero)
            {
                AudioOutputDescriptionStructure nextModule = (AudioOutputDescriptionStructure)Marshal.PtrToStructure(module.NextAudioOutputDescription, typeof(AudioOutputDescriptionStructure));
                var data = GetSubOutputDescription(nextModule, manager, mediaPlayerInstance);
                result.AddRange(data);
            }
            return result;
        }

        public AudioOutputDevices Devices { get; private set; }
    }

}
