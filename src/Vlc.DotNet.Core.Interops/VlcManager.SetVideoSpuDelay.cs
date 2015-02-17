using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetVideoSpuDelay(VlcMediaPlayerInstance mediaPlayerInstance, long delay)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoSpuDelay>().Invoke(mediaPlayerInstance, delay);
        }
    }
}
