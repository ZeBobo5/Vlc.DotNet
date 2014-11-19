using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public IntPtr CreateMediaPlayer(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                throw new ArgumentException("No instance initialized.");
            return GetInteropDelegate<CreateMediaPlayer>().Invoke(instance);
        }
    }
}
