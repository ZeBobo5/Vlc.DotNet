using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public class VlcMediaPlayerEsChangedEventArgs : EventArgs
    {
        public VlcMediaPlayerEsChangedEventArgs(MediaTrackTypes trackType, int id)
        {
            this.TrackType = trackType;
            this.Id = id;
        }

        public MediaTrackTypes TrackType;
        public int Id;
    }
}