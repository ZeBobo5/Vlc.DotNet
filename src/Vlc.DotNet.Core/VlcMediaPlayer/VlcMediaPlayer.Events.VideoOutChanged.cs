using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerVideoOutChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerVideoOutChangedEventArgs> VideoOutChanged;

        private void OnMediaPlayerVideoOutChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerVideoOutChanged(args.eventArgsUnion.MediaPlayerVideoOutChanged.NewCount);
        }

        public void OnMediaPlayerVideoOutChanged(int newCount)
        {
            VideoOutChanged?.Invoke(this, new VlcMediaPlayerVideoOutChangedEventArgs(newCount));
        }
    }
}