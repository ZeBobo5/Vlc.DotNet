using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.TheLuggage
{
    public partial class VlcMedia
    {
        private EventCallback myOnMediaMetaChangedInternalEventCallback;
        public event EventHandler<VlcMediaMetaChangedEventArgs> MetaChanged;

        private void OnMediaMetaChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg) Marshal.PtrToStructure(ptr, typeof (VlcEventArg));
            OnMediaMetaChanged(args.MediaMetaChanged.MetaType);
        }

        public void OnMediaMetaChanged(MediaMetadatas metaType)
        {
            var del = MetaChanged;
            if (del != null)
                del(this, new VlcMediaMetaChangedEventArgs(metaType));
        }
    }
}