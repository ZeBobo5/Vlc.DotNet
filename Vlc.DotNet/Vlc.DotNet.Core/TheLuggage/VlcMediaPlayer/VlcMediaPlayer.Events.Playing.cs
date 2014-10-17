using System;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.TheLuggage
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerPlayingInternalEventCallback;
        public event EventHandler<VlcMediaPlayerPlayingEventArgs> Playing;

        private void OnMediaPlayerPlayingInternal(IntPtr ptr)
        {
            OnMediaPlayerPlaying();
        }

        public void OnMediaPlayerPlaying()
        {
            var del = Playing;
            if (del != null)
                del(this, new VlcMediaPlayerPlayingEventArgs());
        }
    }
}