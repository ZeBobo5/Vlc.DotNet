using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetVideoAspectRatio(VlcMediaPlayerInstance mediaPlayerInstance, string aspectRatio)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");

            using (var aspectRatioInterop = Utf8InteropStringConverter.ToUtf8StringHandle(aspectRatio))
            {
                myLibraryLoader.GetInteropDelegate<SetVideoAspectRatio>().Invoke(mediaPlayerInstance, aspectRatioInterop);
            }
        }
    }
}
