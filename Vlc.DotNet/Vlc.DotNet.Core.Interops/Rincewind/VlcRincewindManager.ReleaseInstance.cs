using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public void ReleaseInstance(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;
            GetInteropDelegate<ReleaseInstance>().Invoke(instance);
            instance = IntPtr.Zero;
        }
    }
}
