using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcMediaPlayerInstance
    {
		public void SetVideoCallbacks(LockVideoCallback lockVideoCallback, UnlockVideoCallback unlockVideoCallback, DisplayVideoCallback displayVideoCallback, IntPtr userData)
        {
            myManager.GetInteropDelegate<SetVideoCallbacks>().Invoke(this.Pointer, lockVideoCallback, unlockVideoCallback, displayVideoCallback, userData);
        }
    }
}
