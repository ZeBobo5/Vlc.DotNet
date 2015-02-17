using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetRate(VlcMediaPlayerInstance mediaPlayerInstance, float rate)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetRate>().Invoke(mediaPlayerInstance, rate);
        }
    }
}
