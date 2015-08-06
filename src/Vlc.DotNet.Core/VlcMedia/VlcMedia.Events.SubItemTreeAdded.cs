using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public partial class VlcMedia
    {
        private EventCallback myOnMediaSubItemTreeAddedInternalEventCallback;
        public event EventHandler<VlcMediaSubItemTreeAddedEventArgs> SubItemTreeAdded;

        private void OnMediaSubItemTreeAddedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg) Marshal.PtrToStructure(ptr, typeof (VlcEventArg));
            OnMediaSubItemTreeAdded(new VlcMedia(myVlcMediaPlayer, VlcMediaInstance.New(myVlcMediaPlayer.Manager, args.MediaSubItemTreeAdded.MediaInstance)));
        }

        public void OnMediaSubItemTreeAdded(VlcMedia newSubItemAdded)
        {
            var del = SubItemTreeAdded;
            if (del != null)
                del(this, new VlcMediaSubItemTreeAddedEventArgs(newSubItemAdded));
        }
    }
}