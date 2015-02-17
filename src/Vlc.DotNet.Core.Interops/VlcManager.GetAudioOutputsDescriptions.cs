using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public AudioOutputDescriptionStructure GetAudioOutputsDescriptions()
        {
            return GetInteropDelegate<GetAudioOutputsDescriptions>().Invoke(myVlcInstance);
        }
    }
}
