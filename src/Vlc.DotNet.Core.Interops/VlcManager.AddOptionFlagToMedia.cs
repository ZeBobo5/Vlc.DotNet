using System;
using System.Runtime.InteropServices;
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void AddOptionFlagToMedia(VlcMediaInstance mediaInstance, string option, uint flag)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");

            using (var handle = Utf8InteropStringConverter.ToUtf8Interop(option))
            {
                GetInteropDelegate<AddOptionFlagToMedia>().Invoke(mediaInstance, handle.DangerousGetHandle(), flag);
            }
        }
    }
}
