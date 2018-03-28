using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerUnmutedInternalEventCallback;
        public event EventHandler Unmuted;

        private void OnMediaPlayerUnmutedInternal(IntPtr ptr)
        {
            OnMediaPlayerUnmuted();
        }

        public void OnMediaPlayerUnmuted()
        {
            Unmuted?.Invoke(this, new EventArgs());
        }
    }
}