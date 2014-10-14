using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMediaPlayer
    {
        public event EventHandler<VlcMediaPlayerVideoOutChangedEventArgs> VideoOutChanged;

        private EventCallback myOnMediaPlayerVideoOutChangedInternalEventCallback;

        private void OnMediaPlayerVideoOutChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
            OnMediaPlayerVideoOutChanged(args.MediaPlayerVideoOutChanged.NewCount);
        }

        public void OnMediaPlayerVideoOutChanged(int newCount)
        {
            var del = VideoOutChanged;
            if (del != null)
                del(this, new VlcMediaPlayerVideoOutChangedEventArgs(newCount));
        }
    }
}
