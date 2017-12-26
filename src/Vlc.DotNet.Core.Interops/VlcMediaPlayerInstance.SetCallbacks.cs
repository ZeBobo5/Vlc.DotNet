using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcMediaPlayerInstance
    {
        [Obsolete]
		public void SetVideoCallbacks(LockVideoCallback lockVideoCallback, UnlockVideoCallback unlockVideoCallback, DisplayVideoCallback displayVideoCallback, IntPtr userData)
        {
            myManager.SetVideoCallbacks(this, lockVideoCallback, unlockVideoCallback, displayVideoCallback, userData);
        }
    }
}
