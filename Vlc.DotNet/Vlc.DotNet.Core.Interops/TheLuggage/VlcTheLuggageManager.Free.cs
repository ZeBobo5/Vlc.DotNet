using System;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcTheLuggageManager
    {
        public void Free(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;
            GetInteropDelegate<Free>().Invoke(instance);
        }
    }
}
