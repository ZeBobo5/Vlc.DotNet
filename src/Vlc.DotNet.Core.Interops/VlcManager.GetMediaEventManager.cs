using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public VlcMediaEventManagerInstance GetMediaEventManager(VlcMediaInstance mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            return new VlcMediaEventManagerInstance(this, GetInteropDelegate<GetMediaEventManager>().Invoke(mediaInstance));
        }
    }
}
