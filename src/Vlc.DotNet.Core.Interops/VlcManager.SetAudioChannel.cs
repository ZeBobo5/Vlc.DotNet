using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetAudioChannel(VlcMediaPlayerInstance mediaPlayerInstance, int channel)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetAudioChannel>().Invoke(mediaPlayerInstance, channel);
        }
    }
}
