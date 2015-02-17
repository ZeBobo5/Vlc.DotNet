using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetMediaPlayerVideoHostHandle(VlcMediaPlayerInstance mediaPlayerInstance, IntPtr videoHostHandle)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetMediaPlayerVideoHostHandle>().Invoke(mediaPlayerInstance, videoHostHandle);
        }
    }
}
