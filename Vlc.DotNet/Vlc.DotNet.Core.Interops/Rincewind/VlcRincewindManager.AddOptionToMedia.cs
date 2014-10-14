using System;
using System.Runtime.InteropServices;
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public void AddOptionToMedia(IntPtr mediaInstance, string option)
        {
            if (string.IsNullOrEmpty(option))
                return;
            var handle = GCHandle.Alloc(Encoding.UTF8.GetBytes(option), GCHandleType.Pinned);
            GetInteropDelegate<AddOptionToMedia>().Invoke(mediaInstance, handle.AddrOfPinnedObject());
            handle.Free();
        }

        public void AddOptionToMedia(IntPtr mediaInstance, string[] options)
        {
            options = options ?? new string[0];
            foreach (var option in options)
            {
                AddOptionToMedia(mediaInstance, option);
            }
        }
    }
}
