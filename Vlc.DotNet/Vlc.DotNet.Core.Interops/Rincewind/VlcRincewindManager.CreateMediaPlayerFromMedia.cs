using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public IntPtr CreateMediaPlayerFromMedia(IntPtr mediaInstance)
        {
            return GetInteropDelegate<CreateMediaPlayerFromMedia>().Invoke(mediaInstance);
        }
    }
}
