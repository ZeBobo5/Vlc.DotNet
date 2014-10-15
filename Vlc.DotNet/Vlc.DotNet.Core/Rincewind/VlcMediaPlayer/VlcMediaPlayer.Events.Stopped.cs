using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerStoppedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerStoppedEventArgs> Stopped;

        private void OnMediaPlayerStoppedInternal(IntPtr ptr)
        {
            OnMediaPlayerStopped();
        }

        public void OnMediaPlayerStopped()
        {
            var del = Stopped;
            if (del != null)
                del(this, new VlcMediaPlayerStoppedEventArgs());
        }
    }
}