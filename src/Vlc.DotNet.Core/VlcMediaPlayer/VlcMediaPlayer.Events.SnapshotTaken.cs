using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    using Vlc.DotNet.Core.Interops;

    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerSnapshotTakenInternalEventCallback;
        public event EventHandler<VlcMediaPlayerSnapshotTakenEventArgs> SnapshotTaken;

        private void OnMediaPlayerSnapshotTakenInternal(IntPtr ptr)
        {
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            var fileName = Utf8InteropStringConverter.Utf8InteropToString(args.eventArgsUnion.MediaPlayerSnapshotTaken.pszFilename);
            OnMediaPlayerSnapshotTaken(fileName);
        }

        public void OnMediaPlayerSnapshotTaken(string fileName)
        {
            var del = SnapshotTaken;
            if (del != null)
                del(this, new VlcMediaPlayerSnapshotTakenEventArgs(fileName));
        }
    }
}