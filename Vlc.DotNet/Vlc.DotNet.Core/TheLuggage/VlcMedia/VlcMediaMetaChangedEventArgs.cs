using System;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.TheLuggage
{
    public class VlcMediaMetaChangedEventArgs : EventArgs
    {
        public VlcMediaMetaChangedEventArgs(MediaMetadatas metaType)
        {
            MetaType = metaType;
        }

        public MediaMetadatas MetaType { get; private set; }
    }
}