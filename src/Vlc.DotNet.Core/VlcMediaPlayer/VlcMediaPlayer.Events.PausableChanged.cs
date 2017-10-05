using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerPausableChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerPausableChangedEventArgs> PausableChanged;

        private void OnMediaPlayerPausableChangedInternal(IntPtr ptr)
        {
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            OnMediaPlayerPausableChanged(args.eventArgsUnion.MediaPlayerPausableChanged.NewPausable == 1);
        }

        public void OnMediaPlayerPausableChanged(bool paused)
        {
            var del = PausableChanged;
            if (del != null)
                del(this, new VlcMediaPlayerPausableChangedEventArgs(paused));
        }
    }
}