using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void Free(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;
            GetInteropDelegate<Free>().Invoke(instance);
        }
    }
}
