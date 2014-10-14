using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMediaPlayer
    {
        public event EventHandler<VlcMediaPlayerPositionChangedEventArgs> PositionChanged;

        private EventCallback myOnMediaPlayerPositionChangedInternalEventCallback;

        private void OnMediaPlayerPositionChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
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
