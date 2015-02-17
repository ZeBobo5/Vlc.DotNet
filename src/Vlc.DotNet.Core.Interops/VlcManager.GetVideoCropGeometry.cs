using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public string GetVideoCropGeometry(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
#if NET20
            return IntPtrExtensions.ToStringAnsi(GetInteropDelegate<GetVideoCropGeometry>().Invoke(mediaPlayerInstance));
#else
            return GetInteropDelegate<GetVideoCropGeometry>().Invoke(mediaPlayerInstance).ToStringAnsi();
#endif
        }
    }
}
