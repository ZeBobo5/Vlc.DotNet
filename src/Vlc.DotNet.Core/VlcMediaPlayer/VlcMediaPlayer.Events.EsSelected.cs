using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerEsSelectedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerEsChangedEventArgs> EsSelected;

        private void OnMediaPlayerEsSelectedInternal(IntPtr ptr)
        {
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            OnMediaPlayerEsSelected(args.eventArgsUnion.MediaPlayerEsChanged);
        }

        public void OnMediaPlayerEsSelected(MediaPlayerEsChanged eventArgs)
        {
            EsSelected?.Invoke(this, new VlcMediaPlayerEsChangedEventArgs(eventArgs.TrackType, eventArgs.Id));
        }
    }
}