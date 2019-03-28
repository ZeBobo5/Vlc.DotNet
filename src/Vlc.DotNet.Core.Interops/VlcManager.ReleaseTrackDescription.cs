using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void ReleaseTrackDescription(IntPtr trackDescription)
        {
            myLibraryLoader.GetInteropDelegate<ReleaseTrackDescription>().Invoke(trackDescription);
        }
    }
}
