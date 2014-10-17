using System;

namespace Vlc.DotNet.Core.TheLuggage
{
    public sealed class VlcMediaPlayerMediaChangedEventArgs : EventArgs
    {
        public VlcMediaPlayerMediaChangedEventArgs(VlcMedia newMedia)
        {
            NewMedia = newMedia;
        }

        public VlcMedia NewMedia { get; private set; }
    }
}