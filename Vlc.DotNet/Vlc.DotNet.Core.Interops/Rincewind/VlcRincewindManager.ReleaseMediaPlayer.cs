using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public void ReleaseMediaPlayer(IntPtr mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                return;
            GetInteropDelegate<ReleaseMediaPlayer>().Invoke(mediaPlayerInstance);
            mediaPlayerInstance = IntPtr.Zero;
        }
    }
}
