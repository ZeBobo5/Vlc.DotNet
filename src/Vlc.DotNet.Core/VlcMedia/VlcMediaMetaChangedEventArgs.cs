using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
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