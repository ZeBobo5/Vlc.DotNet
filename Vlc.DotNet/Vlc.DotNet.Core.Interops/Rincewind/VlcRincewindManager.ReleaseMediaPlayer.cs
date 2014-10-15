using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public void ReleaseMediaPlayer(IntPtr mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<ReleaseMediaPlayer>().Invoke(mediaPlayerInstance);
            mediaPlayerInstance = IntPtr.Zero;
        }
    }
}
