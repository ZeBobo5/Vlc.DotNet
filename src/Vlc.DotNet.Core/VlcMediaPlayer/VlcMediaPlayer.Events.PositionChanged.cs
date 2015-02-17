using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerPositionChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerPositionChangedEventArgs> PositionChanged;

        private void OnMediaPlayerPositionChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg) Marshal.PtrToStructure(ptr, typeof (VlcEventArg));
            OnMediaPlayerPositionChanged(args.MediaPlayerPositionChanged.NewPosition);
        }

        public void OnMediaPlayerPositionChanged(float newPosition)
        {
            var del = PositionChanged;
            if (del != null)
                del(this, new VlcMediaPlayerPositionChangedEventArgs(newPosition));
        }
    }
}