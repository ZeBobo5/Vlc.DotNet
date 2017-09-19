﻿using System;
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
            var args = (VlcEventArg) Marshal.PtrToStructure(ptr, typeof (VlcEventArg));
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