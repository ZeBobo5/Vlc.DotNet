using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerEndReachedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerEndReachedEventArgs> EndReached;

        private void OnMediaPlayerEndReachedInternal(IntPtr ptr)
        {
            //ResetFromMedia();
            OnMediaPlayerEndReached();
        }

        public void OnMediaPlayerEndReached()
        {
            var del = EndReached;
            if (del != null)
                del(this, new VlcMediaPlayerEndReachedEventArgs());
        }
    }
}
