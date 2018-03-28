using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerEsDeletedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerEsChangedEventArgs> EsDeleted;

        private void OnMediaPlayerEsDeletedInternal(IntPtr ptr)
        {
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            OnMediaPlayerEsDeleted(args.eventArgsUnion.MediaPlayerEsChanged);
        }

        public void OnMediaPlayerEsDeleted(MediaPlayerEsChanged eventArgs)
        {
            EsDeleted?.Invoke(this, new VlcMediaPlayerEsChangedEventArgs(eventArgs.TrackType, eventArgs.Id));
        }
    }
}