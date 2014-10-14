using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public void ReleaseInstance(IntPtr instance)
        {
            GetInteropDelegate<ReleaseInstance>().Invoke(instance);
            instance = IntPtr.Zero;
        }
    }
}
