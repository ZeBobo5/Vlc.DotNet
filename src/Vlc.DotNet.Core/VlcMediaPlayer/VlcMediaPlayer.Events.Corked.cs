using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerCorkedInternalEventCallback;
        public event EventHandler Corked;

        private void OnMediaPlayerCorkedInternal(IntPtr ptr)
        {
            OnMediaPlayerCorked();
        }

        public void OnMediaPlayerCorked()
        {
            Corked?.Invoke(this, new EventArgs());
        }
    }
}