using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerTitleChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerTitleChangedEventArgs> TitleChanged;

        private void OnMediaPlayerTitleChangedInternal(IntPtr ptr)
        {
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            OnMediaPlayerTitleChanged(args.eventArgsUnion.MediaPlayerTitleChanged.NewTitle);
        }

        public void OnMediaPlayerTitleChanged(int newTitle)
        {
            var del = TitleChanged;
            if (del != null)
                del(this, new VlcMediaPlayerTitleChangedEventArgs(newTitle));
        }
    }
}