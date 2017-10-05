using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerBufferingInternalEventCallback;
        public event EventHandler<VlcMediaPlayerBufferingEventArgs> Buffering;

        private void OnMediaPlayerBufferingInternal(IntPtr ptr)
        {
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            OnMediaPlayerBuffering(args.eventArgsUnion.MediaPlayerBuffering.NewCache);
        }

        public void OnMediaPlayerBuffering(float newCache)
        {
            var del = Buffering;
            if (del != null)
                del(this, new VlcMediaPlayerBufferingEventArgs(newCache));
        }
    }
}