using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerMediaChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerMediaChangedEventArgs> MediaChanged;

        private void OnMediaPlayerMediaChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg) Marshal.PtrToStructure(ptr, typeof (VlcEventArg));

            OnMediaPlayerMediaChanged(new VlcMedia(this, VlcMediaInstance.New(Manager, args.MediaPlayerMediaChanged.MediaInstance)));
        }

        public void OnMediaPlayerMediaChanged(VlcMedia media)
        {
            var del = MediaChanged;
            if (del != null)
                del(this, new VlcMediaPlayerMediaChangedEventArgs(media));
        }
    }
}