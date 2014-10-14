using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMediaPlayer
    {
        public event EventHandler<VlcMediaPlayerEndReachedEventArgs> EndReached;

        private EventCallback myOnMediaPlayerEndReachedInternalEventCallback;

        private void OnMediaPlayerEndReachedInternal(IntPtr ptr)
        {
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
