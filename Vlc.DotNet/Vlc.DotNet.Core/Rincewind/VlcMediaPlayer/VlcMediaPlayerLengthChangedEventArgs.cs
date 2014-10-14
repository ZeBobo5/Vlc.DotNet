using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerLengthChangedEventArgs : EventArgs
    {
        public float NewLength { get; private set; }

        public VlcMediaPlayerLengthChangedEventArgs(float newLength)
        {
            NewLength = newLength;
        }
    }
}
