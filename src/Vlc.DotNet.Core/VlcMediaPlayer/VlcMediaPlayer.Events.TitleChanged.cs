using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    using Vlc.DotNet.Core.Interops;

    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerTitleChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerTitleChangedEventArgs> TitleChanged;

        private void OnMediaPlayerTitleChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg) Marshal.PtrToStructure(ptr, typeof (VlcEventArg));
            var fileName = Utf8InteropStringConverter.Utf8InteropToString(args.eventArgsUnion.MediaPlayerTitleChanged.NewTitle);
            OnMediaPlayerTitleChanged(fileName);
        }

        public void OnMediaPlayerTitleChanged(string fileName)
        {
            var del = TitleChanged;
            if (del != null)
                del(this, new VlcMediaPlayerTitleChangedEventArgs(fileName));
        }
    }
}