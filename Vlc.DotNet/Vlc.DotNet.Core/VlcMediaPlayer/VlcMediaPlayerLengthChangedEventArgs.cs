using System;

namespace Vlc.DotNet.Core
{
    public sealed class VlcMediaPlayerLengthChangedEventArgs : EventArgs
    {
        public VlcMediaPlayerLengthChangedEventArgs(float newLength)
        {
            NewLength = newLength;
        }

        public float NewLength { get; private set; }
    }
}