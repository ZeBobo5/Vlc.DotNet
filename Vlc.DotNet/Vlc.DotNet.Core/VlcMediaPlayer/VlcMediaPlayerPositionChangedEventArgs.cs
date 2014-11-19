using System;

namespace Vlc.DotNet.Core
{
    public sealed class VlcMediaPlayerPositionChangedEventArgs : EventArgs
    {
        public VlcMediaPlayerPositionChangedEventArgs(float newPosition)
        {
            NewPosition = newPosition;
        }

        public float NewPosition { get; private set; }
    }
}