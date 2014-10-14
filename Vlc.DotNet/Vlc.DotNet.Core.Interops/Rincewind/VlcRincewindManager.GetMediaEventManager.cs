using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public IntPtr GetMediaEventManager(IntPtr mediaInstance)
        {
            return GetInteropDelegate<GetMediaEventManager>().Invoke(mediaInstance);
        }
    }
}
