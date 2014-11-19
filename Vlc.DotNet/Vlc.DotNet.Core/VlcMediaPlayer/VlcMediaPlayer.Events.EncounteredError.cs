using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerEncounteredErrorInternalEventCallback;
        public event EventHandler<VlcMediaPlayerEncounteredErrorEventArgs> EncounteredError;

        private void OnMediaPlayerEncounteredErrorInternal(IntPtr ptr)
        {
            OnMediaPlayerEncounteredError();
        }

        public void OnMediaPlayerEncounteredError()
        {
            var del = EncounteredError;
            if (del != null)
                del(this, new VlcMediaPlayerEncounteredErrorEventArgs());
        }
    }
}