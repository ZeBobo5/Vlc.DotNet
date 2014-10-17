using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.TheLuggage
{
    public partial class VlcMedia
    {
        private EventCallback myOnMediaSubItemAddedInternalEventCallback;
        public event EventHandler<VlcMediaSubItemAddedEventArgs> SubItemTreeAdded;

        private void OnMediaSubItemAddedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg) Marshal.PtrToStructure(ptr, typeof (VlcEventArg));
            OnMediaSubItemAdded(new VlcMedia(myVlcMediaPlayer, args.MediaSubItemAdded.MediaInstance));
        }

        public void OnMediaSubItemAdded(VlcMedia newSubItemAdded)
        {
            var del = SubItemTreeAdded;
            if (del != null)
                del(this, new VlcMediaSubItemAddedEventArgs(newSubItemAdded));
        }
    }
}