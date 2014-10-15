using System;

namespace Vlc.DotNet.Core.Rincewind
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