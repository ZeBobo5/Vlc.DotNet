using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.TheLuggage
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerSeekableChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerSeekableChangedEventArgs> SeekableChanged;

        private void OnMediaPlayerSeekableChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg) Marshal.PtrToStructure(ptr, typeof (VlcEventArg));
            OnMediaPlayerSeekableChanged(args.MediaPlayerSeekableChanged.NewSeekable);
        }

        public void OnMediaPlayerSeekableChanged(int newSeekable)
        {
            var del = SeekableChanged;
            if (del != null)
                del(this, new VlcMediaPlayerSeekableChangedEventArgs(newSeekable));
        }
    }
}