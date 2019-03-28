using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetPause(VlcMediaPlayerInstance mediaPlayerInstance, bool isPause)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            myLibraryLoader.GetInteropDelegate<SetPause>().Invoke(mediaPlayerInstance, isPause);
        }
    }
}
