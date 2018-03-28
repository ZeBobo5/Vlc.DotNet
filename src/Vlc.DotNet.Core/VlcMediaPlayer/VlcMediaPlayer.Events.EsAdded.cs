using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerEsAddedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerEsChangedEventArgs> EsAdded;

        private void OnMediaPlayerEsAddedInternal(IntPtr ptr)
        {
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            OnMediaPlayerEsAdded(args.eventArgsUnion.MediaPlayerEsChanged);
        }

        public void OnMediaPlayerEsAdded(MediaPlayerEsChanged eventArgs)
        {
            EsAdded?.Invoke(this, new VlcMediaPlayerEsChangedEventArgs(eventArgs.TrackType, eventArgs.Id));
        }
    }
}