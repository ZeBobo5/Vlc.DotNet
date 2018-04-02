using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerTitleChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerTitleChangedEventArgs> TitleChanged;

        private void OnMediaPlayerTitleChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerTitleChanged(args.eventArgsUnion.MediaPlayerTitleChanged.NewTitle);
        }

        public void OnMediaPlayerTitleChanged(int newTitle)
        {
            TitleChanged?.Invoke(this, new VlcMediaPlayerTitleChangedEventArgs(newTitle));
        }
    }
}