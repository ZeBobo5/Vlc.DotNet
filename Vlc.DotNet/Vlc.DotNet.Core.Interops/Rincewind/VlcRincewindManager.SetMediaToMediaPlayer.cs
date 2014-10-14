using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public void SetMediaToMediaPlayer(IntPtr mediaPlayerInstance, IntPtr mediaInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                return;
            GetInteropDelegate<SetMediaToMediaPlayer>().Invoke(mediaPlayerInstance, mediaInstance);
        }
    }
}
