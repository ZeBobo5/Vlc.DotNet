using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerSnapshotTakenInternalEventCallback;
        public event EventHandler<VlcMediaPlayerSnapshotTakenEventArgs> SnapshotTaken;

        private void OnMediaPlayerSnapshotTakenInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            var fileName = Utf8InteropStringConverter.Utf8InteropToString(args.eventArgsUnion.MediaPlayerSnapshotTaken.pszFilename);
            OnMediaPlayerSnapshotTaken(fileName);
        }

        public void OnMediaPlayerSnapshotTaken(string fileName)
        {
            SnapshotTaken?.Invoke(this, new VlcMediaPlayerSnapshotTakenEventArgs(fileName));
        }
    }
}