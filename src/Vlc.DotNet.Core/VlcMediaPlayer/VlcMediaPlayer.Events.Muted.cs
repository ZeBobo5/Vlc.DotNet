using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerMutedInternalEventCallback;
        public event EventHandler Muted;

        private void OnMediaPlayerMutedInternal(IntPtr ptr)
        {
            OnMediaPlayerMuted();
        }

        public void OnMediaPlayerMuted()
        {
            Muted?.Invoke(this, new EventArgs());
        }
    }
}