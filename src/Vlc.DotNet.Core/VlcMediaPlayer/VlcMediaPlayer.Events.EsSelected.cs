using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerEsSelectedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerEsChangedEventArgs> EsSelected;

        private void OnMediaPlayerEsSelectedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerEsSelected(args.eventArgsUnion.MediaPlayerEsChanged);
        }

        public void OnMediaPlayerEsSelected(MediaPlayerEsChanged eventArgs)
        {
            EsSelected?.Invoke(this, new VlcMediaPlayerEsChangedEventArgs(eventArgs.TrackType, eventArgs.Id));
        }
    }
}