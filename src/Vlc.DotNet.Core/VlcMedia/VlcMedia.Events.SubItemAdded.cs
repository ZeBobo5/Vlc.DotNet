﻿using System;
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
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            OnMediaSubItemAdded(new VlcMedia(myVlcMediaPlayer, VlcMediaInstance.New(myVlcMediaPlayer.Manager, args.eventArgsUnion.MediaSubItemAdded.NewChild)));
        }

        public void OnMediaSubItemAdded(VlcMedia newSubItemAdded)
        {
            var del = SubItemAdded;
            if (del != null)
                del(this, new VlcMediaSubItemAddedEventArgs(newSubItemAdded));
        }
    }
}