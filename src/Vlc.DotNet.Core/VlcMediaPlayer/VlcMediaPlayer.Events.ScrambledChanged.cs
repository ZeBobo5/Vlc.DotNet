using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerScrambledChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerScrambledChangedEventArgs> ScrambledChanged;

        private void OnMediaPlayerScrambledChangedInternal(IntPtr ptr)
        {
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            OnMediaPlayerScrambledChanged(args.eventArgsUnion.MediaPlayerScrambledChanged.NewScrambled);
        }

        public void OnMediaPlayerScrambledChanged(int newScrambled)
        {
            var del = ScrambledChanged;
            if (del != null)
                del(this, new VlcMediaPlayerScrambledChangedEventArgs(newScrambled));
        }
    }
}