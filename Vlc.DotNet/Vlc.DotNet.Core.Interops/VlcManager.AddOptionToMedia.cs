using System;
using System.Runtime.InteropServices;
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void AddOptionToMedia(IntPtr mediaInstance, string option)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            if (string.IsNullOrEmpty(option))
                return;
            var handle = GCHandle.Alloc(Encoding.UTF8.GetBytes(option), GCHandleType.Pinned);
            GetInteropDelegate<AddOptionToMedia>().Invoke(mediaInstance, handle.AddrOfPinnedObject());
            handle.Free();
        }

        public void AddOptionToMedia(IntPtr mediaInstance, string[] options)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            options = options ?? new string[0];
            foreach (var option in options)
            {
                AddOptionToMedia(mediaInstance, option);
            }
        }
    }
}
