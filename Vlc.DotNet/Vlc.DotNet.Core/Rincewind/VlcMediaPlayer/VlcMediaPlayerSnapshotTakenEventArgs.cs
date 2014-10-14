using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerSnapshotTakenEventArgs : EventArgs
    {
        public string FileName { get; private set; }

        public VlcMediaPlayerSnapshotTakenEventArgs(string fileName)
        {
            FileName = fileName;
        }
    }
}
