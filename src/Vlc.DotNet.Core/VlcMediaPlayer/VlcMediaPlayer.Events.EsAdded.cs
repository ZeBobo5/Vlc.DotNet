using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerEsAddedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerEsChangedEventArgs> EsAdded;

        private void OnMediaPlayerEsAddedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerEsAdded(args.eventArgsUnion.MediaPlayerEsChanged);
        }

        public void OnMediaPlayerEsAdded(MediaPlayerEsChanged eventArgs)
        {
            EsAdded?.Invoke(this, new VlcMediaPlayerEsChangedEventArgs(eventArgs.TrackType, eventArgs.Id));
        }
    }
}