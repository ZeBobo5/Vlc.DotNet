using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public ModuleDescription GetAudioFilterList()
        {
            return GetInteropDelegate<GetAudioFilterList>().Invoke(myVlcInstance);
        }
    }
}
