using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {

        public void SetVideoCallbacks(VlcMediaPlayerInstance mediaPlayerInstance, LockVideoCallback lockVideoCallback, UnlockVideoCallback unlockVideoCallback, DisplayVideoCallback displayVideoCallback, IntPtr userData)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");

            myLibraryLoader.GetInteropDelegate<SetVideoCallbacks>().Invoke(mediaPlayerInstance, lockVideoCallback, unlockVideoCallback, displayVideoCallback, userData);
        }
    }
}
