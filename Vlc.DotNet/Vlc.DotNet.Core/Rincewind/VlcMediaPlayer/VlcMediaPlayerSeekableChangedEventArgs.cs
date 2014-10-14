using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerSeekableChangedEventArgs : EventArgs
    {
        public int NewSeekable { get; private set; }

        public VlcMediaPlayerSeekableChangedEventArgs(int newSeekable)
        {
            NewSeekable = newSeekable;
        }
    }
}
