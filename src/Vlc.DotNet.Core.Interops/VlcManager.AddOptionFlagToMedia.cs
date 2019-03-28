using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void AddOptionFlagToMedia(VlcMediaInstance mediaInstance, string option, uint flag)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");

            using (var handle = Utf8InteropStringConverter.ToUtf8StringHandle(option))
            {
                myLibraryLoader.GetInteropDelegate<AddOptionFlagToMedia>().Invoke(mediaInstance, handle, flag);
            }
        }
    }
}
