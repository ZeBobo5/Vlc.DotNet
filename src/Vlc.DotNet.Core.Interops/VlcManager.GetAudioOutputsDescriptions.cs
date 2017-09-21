using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public AudioOutputDescriptionStructure GetAudioOutputsDescriptions()
        {
            EnsureVlcInstance();

            return GetInteropDelegate<GetAudioOutputsDescriptions>().Invoke(myVlcInstance);
        }
    }
}
