using System;

namespace Vlc.DotNet.Core
{
    public sealed class VlcMediaPlayerLengthChangedEventArgs : EventArgs
    {
        public VlcMediaPlayerLengthChangedEventArgs(long newLength)
        {
            NewLength = newLength;
        }

        public long NewLength { get; private set; }
    }
}
