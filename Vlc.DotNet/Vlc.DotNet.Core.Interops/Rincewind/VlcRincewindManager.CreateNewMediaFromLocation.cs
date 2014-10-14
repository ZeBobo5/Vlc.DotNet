using System;
using System.Runtime.InteropServices;
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public IntPtr CreateNewMediaFromLocation(IntPtr instance, string mrl)
        {
            var handle = GCHandle.Alloc(Encoding.UTF8.GetBytes(mrl), GCHandleType.Pinned);
            var result = GetInteropDelegate<CreateNewMediaFromLocation>().Invoke(instance, handle.AddrOfPinnedObject());
            handle.Free();
            return result;
        }
    }
}
