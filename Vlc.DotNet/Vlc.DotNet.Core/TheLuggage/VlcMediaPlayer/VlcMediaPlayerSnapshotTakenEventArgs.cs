using System;

namespace Vlc.DotNet.Core.TheLuggage
{
    public sealed class VlcMediaPlayerSnapshotTakenEventArgs : EventArgs
    {
        public VlcMediaPlayerSnapshotTakenEventArgs(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }
    }
}