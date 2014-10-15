using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerSeekableChangedEventArgs : EventArgs
    {
        public VlcMediaPlayerSeekableChangedEventArgs(int newSeekable)
        {
            NewSeekable = newSeekable;
        }

        public int NewSeekable { get; private set; }
    }
}