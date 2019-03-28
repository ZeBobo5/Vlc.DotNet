using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void ReleaseModuleDescriptionInstance(IntPtr moduleDescriptionInstance)
        {
            myLibraryLoader.GetInteropDelegate<ReleaseModuleDescription>().Invoke(moduleDescriptionInstance);
        }
    }
}
