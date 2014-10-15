using System;

namespace Vlc.DotNet.Core.Rincewind
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