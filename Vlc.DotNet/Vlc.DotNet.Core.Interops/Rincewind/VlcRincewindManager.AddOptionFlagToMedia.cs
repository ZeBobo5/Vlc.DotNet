using System;
using System.Runtime.InteropServices;
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public void AddOptionFlagToMedia(IntPtr mediaInstance, string option, uint flag)
        {
            var handle = GCHandle.Alloc(Encoding.UTF8.GetBytes(option), GCHandleType.Pinned);
            GetInteropDelegate<AddOptionFlagToMedia>().Invoke(mediaInstance, handle.AddrOfPinnedObject(), flag);
            handle.Free();
        }
    }
}
