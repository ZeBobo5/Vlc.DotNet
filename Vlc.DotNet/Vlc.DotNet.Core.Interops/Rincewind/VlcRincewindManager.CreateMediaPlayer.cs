using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public IntPtr CreateMediaPlayer(IntPtr instance)
        {
            return GetInteropDelegate<CreateMediaPlayer>().Invoke(instance);
        }
    }
}
