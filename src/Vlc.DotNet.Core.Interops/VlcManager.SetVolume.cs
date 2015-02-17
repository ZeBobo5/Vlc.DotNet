using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetVolume(VlcMediaPlayerInstance mediaPlayerInstance, int volume)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVolume>().Invoke(mediaPlayerInstance, volume);
        }
    }
}
