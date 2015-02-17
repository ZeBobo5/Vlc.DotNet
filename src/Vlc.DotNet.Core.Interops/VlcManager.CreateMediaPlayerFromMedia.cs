using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public VlcMediaPlayerInstance CreateMediaPlayerFromMedia(VlcMediaInstance mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            return new VlcMediaPlayerInstance(this, GetInteropDelegate<CreateMediaPlayerFromMedia>().Invoke(mediaInstance));
        }
    }
}
