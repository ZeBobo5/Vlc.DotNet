using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public VlcMediaInstance GetMediaFromMediaPlayer(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return VlcMediaInstance.New(this, GetInteropDelegate<GetMediaFromMediaPlayer>().Invoke(mediaPlayerInstance));
        }
    }
}
