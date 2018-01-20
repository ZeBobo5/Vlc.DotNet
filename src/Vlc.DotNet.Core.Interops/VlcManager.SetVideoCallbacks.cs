using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        private LockVideoCallback _lockVideoCallbackReference;
        private UnlockVideoCallback _unlockVideoCallbackReference;
        private DisplayVideoCallback _displayVideoCallbackReference;

        public void SetVideoCallbacks(VlcMediaPlayerInstance mediaPlayerInstance, LockVideoCallback lockVideoCallback, UnlockVideoCallback unlockVideoCallback, DisplayVideoCallback displayVideoCallback, IntPtr userData)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");

            this._lockVideoCallbackReference = lockVideoCallback;
            this._unlockVideoCallbackReference = unlockVideoCallback;
            this._displayVideoCallbackReference = displayVideoCallback;

            GetInteropDelegate<SetVideoCallbacks>().Invoke(mediaPlayerInstance, this._lockVideoCallbackReference, this._unlockVideoCallbackReference, this._displayVideoCallbackReference, userData);
        }
    }
}
