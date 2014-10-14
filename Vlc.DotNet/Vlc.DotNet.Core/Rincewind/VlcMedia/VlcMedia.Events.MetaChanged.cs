using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMedia
    {
        public event EventHandler<VlcMediaMetaChangedEventArgs> MetaChanged;

        private EventCallback myOnMediaMetaChangedInternalEventCallback;

        private void OnMediaMetaChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
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
