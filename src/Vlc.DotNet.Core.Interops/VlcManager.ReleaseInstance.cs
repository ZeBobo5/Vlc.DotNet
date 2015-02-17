using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void ReleaseInstance(VlcIntance instance)
        {
            if (instance == IntPtr.Zero)
                return;
            GetInteropDelegate<ReleaseInstance>().Invoke(instance);
        }
    }
}
