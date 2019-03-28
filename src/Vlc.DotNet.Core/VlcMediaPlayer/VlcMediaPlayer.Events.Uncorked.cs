using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerUncorkedInternalEventCallback;
        public event EventHandler Uncorked;

        private void OnMediaPlayerUncorkedInternal(IntPtr ptr)
        {
            OnMediaPlayerUncorked();
        }

        public void OnMediaPlayerUncorked()
        {
            Uncorked?.Invoke(this, new EventArgs());
        }
    }
}