using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerPositionChangedEventArgs : EventArgs
    {
        public float NewPosition { get; private set; }

        public VlcMediaPlayerPositionChangedEventArgs(float newPosition)
        {
            NewPosition = newPosition;
        }
    }
}
