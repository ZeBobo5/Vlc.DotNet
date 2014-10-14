using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMediaPlayer
    {
        public event EventHandler<VlcMediaPlayerBackwardEventArgs> Backward;

        private EventCallback myOnMediaPlayerBackwardInternalEventCallback;

        private void OnMediaPlayerBackwardInternal(IntPtr ptr)
        {
            OnMediaPlayerBackward();
        }

        public void OnMediaPlayerBackward()
        {
            var del = Backward;
            if (del != null)
                del(this, new VlcMediaPlayerBackwardEventArgs());
        }
    }
}
