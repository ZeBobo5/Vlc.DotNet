using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {

        public void SetVideoFormatCallbacks(VlcMediaPlayerInstance mediaPlayerInstance, VideoFormatCallback videoFormatCallback, CleanupVideoCallback cleanupCallback)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");

            myLibraryLoader.GetInteropDelegate<SetVideoFormatCallbacks>().Invoke(mediaPlayerInstance, videoFormatCallback, cleanupCallback);
        }
    }
}
