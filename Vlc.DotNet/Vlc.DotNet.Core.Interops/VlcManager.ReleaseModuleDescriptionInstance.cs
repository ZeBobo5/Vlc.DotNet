using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void ReleaseModuleDescriptionInstance(ModuleDescription moduleDescriptionInstance)
        {
            GetInteropDelegate<ReleaseModuleDescription>().Invoke(moduleDescriptionInstance);
        }
    }
}
