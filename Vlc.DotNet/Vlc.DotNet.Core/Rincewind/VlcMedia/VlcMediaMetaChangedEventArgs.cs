using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public class VlcMediaMetaChangedEventArgs : EventArgs
    {
        public MediaMetadatas MetaType { get; private set; }

        public VlcMediaMetaChangedEventArgs(MediaMetadatas metaType)
        {
            MetaType = metaType;
        }
    }
}
