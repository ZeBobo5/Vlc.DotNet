using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void Navigate(VlcMediaPlayerInstance mediaPlayerInstance, NavigateModes navigateMode)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<Navigate>().Invoke(mediaPlayerInstance, navigateMode);
        }
    }
}
