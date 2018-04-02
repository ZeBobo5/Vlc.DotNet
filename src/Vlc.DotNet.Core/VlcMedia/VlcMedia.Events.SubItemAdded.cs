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
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaSubItemAdded(new VlcMedia(myVlcMediaPlayer, VlcMediaInstance.New(myVlcMediaPlayer.Manager, args.eventArgsUnion.MediaSubItemAdded.NewChild)));
        }

        public void OnMediaSubItemAdded(VlcMedia newSubItemAdded)
        {
            SubItemAdded?.Invoke(this, new VlcMediaSubItemAddedEventArgs(newSubItemAdded));
        }
    }
}