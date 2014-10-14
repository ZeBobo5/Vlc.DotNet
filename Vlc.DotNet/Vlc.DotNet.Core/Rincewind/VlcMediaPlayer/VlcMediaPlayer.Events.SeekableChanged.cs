using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMediaPlayer
    {
        public event EventHandler<VlcMediaPlayerSeekableChangedEventArgs> SeekableChanged;

        private EventCallback myOnMediaPlayerSeekableChangedInternalEventCallback;

        private void OnMediaPlayerSeekableChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
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
