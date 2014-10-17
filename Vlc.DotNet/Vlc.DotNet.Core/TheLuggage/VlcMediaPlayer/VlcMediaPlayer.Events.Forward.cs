using System;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.TheLuggage
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerForwardInternalEventCallback;
        public event EventHandler<VlcMediaPlayerForwardEventArgs> Forward;

        private void OnMediaPlayerForwardInternal(IntPtr ptr)
        {
            OnMediaPlayerForward();
        }

        public void OnMediaPlayerForward()
        {
            var del = Forward;
            if (del != null)
                del(this, new VlcMediaPlayerForwardEventArgs());
        }
    }
}