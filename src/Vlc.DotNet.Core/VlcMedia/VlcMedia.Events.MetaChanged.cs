using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public partial class VlcMedia
    {
        private EventCallback myOnMediaMetaChangedInternalEventCallback;
        public event EventHandler<VlcMediaMetaChangedEventArgs> MetaChanged;

        private void OnMediaMetaChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaMetaChanged(args.eventArgsUnion.MediaMetaChanged.MetaType);
        }

        public void OnMediaMetaChanged(MediaMetadatas metaType)
        {
            MetaChanged?.Invoke(this, new VlcMediaMetaChangedEventArgs(metaType));
        }
    }
}