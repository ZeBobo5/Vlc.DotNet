using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public partial class VlcMedia
    {
        private EventCallback myOnMediaSubItemAddedInternalEventCallback;
        public event EventHandler<VlcMediaSubItemAddedEventArgs> SubItemAdded;

        private void OnMediaSubItemAddedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg) Marshal.PtrToStructure(ptr, typeof (VlcEventArg));
            OnMediaSubItemAdded(new VlcMedia(myVlcMediaPlayer, VlcMediaInstance.New(myVlcMediaPlayer.Manager, args.MediaSubItemAdded.NewChild)));
        }

        public void OnMediaSubItemAdded(VlcMedia newSubItemAdded)
        {
            var del = SubItemAdded;
            if (del != null)
                del(this, new VlcMediaSubItemAddedEventArgs(newSubItemAdded));
        }
    }
}