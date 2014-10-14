using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public void ReleaseMedia(IntPtr mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                return;
            GetInteropDelegate<ReleaseMedia>().Invoke(mediaInstance);
            mediaInstance = IntPtr.Zero;
        }
    }
}
