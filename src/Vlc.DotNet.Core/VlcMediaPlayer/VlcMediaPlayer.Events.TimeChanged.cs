using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerTimeChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerTimeChangedEventArgs> TimeChanged;

        private void OnMediaPlayerTimeChangedInternal(IntPtr ptr)
        {
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            OnMediaPlayerTimeChanged(args.eventArgsUnion.MediaPlayerTimeChanged.NewTime);
        }

        public void OnMediaPlayerTimeChanged(long newTime)
        {
            var del = TimeChanged;
            if (del != null)
                del(this, new VlcMediaPlayerTimeChangedEventArgs(newTime));
        }
    }
}