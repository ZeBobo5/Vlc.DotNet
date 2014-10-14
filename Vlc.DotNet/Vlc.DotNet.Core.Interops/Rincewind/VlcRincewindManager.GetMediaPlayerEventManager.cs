using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public IntPtr GetMediaPlayerEventManager(IntPtr mediaPlayerInstance)
        {
            return GetInteropDelegate<GetMediaPlayerEventManager>().Invoke(mediaPlayerInstance);
        }
    }
}
