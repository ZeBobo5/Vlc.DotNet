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
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaSubItemTreeAdded(new VlcMedia(myVlcMediaPlayer, VlcMediaInstance.New(myVlcMediaPlayer.Manager, args.eventArgsUnion.MediaSubItemTreeAdded.MediaInstance)));
        }

        public void OnMediaSubItemTreeAdded(VlcMedia newSubItemAdded)
        {
            SubItemTreeAdded?.Invoke(this, new VlcMediaSubItemTreeAddedEventArgs(newSubItemAdded));
        }
    }
}