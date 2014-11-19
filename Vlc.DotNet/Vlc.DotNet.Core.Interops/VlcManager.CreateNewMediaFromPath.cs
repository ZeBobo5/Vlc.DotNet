using System;
using System.Runtime.InteropServices;
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public IntPtr CreateNewMediaFromPath(IntPtr instance, string mrl)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("No instance initialized.");
            var handle = GCHandle.Alloc(Encoding.UTF8.GetBytes(mrl), GCHandleType.Pinned);
            var result = GetInteropDelegate<CreateNewMediaFromPath>().Invoke(instance, handle.AddrOfPinnedObject());
            handle.Free();
            return result;
        }
    }
}
