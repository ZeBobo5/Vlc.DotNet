using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public IntPtr CloneMedia(IntPtr mediaIinstance)
        {
            if (mediaIinstance == IntPtr.Zero)
                return IntPtr.Zero;
            return GetInteropDelegate<CloneMedia>().Invoke(mediaIinstance);
        }
    }
}
