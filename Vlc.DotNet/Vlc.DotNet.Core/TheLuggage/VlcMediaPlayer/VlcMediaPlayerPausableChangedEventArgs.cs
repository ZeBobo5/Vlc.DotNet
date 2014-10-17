using System;

namespace Vlc.DotNet.Core.TheLuggage
{
    public sealed class VlcMediaPlayerPausableChangedEventArgs : EventArgs
    {
        public VlcMediaPlayerPausableChangedEventArgs(bool paused)
        {
            IsPaused = paused;
        }

        public bool IsPaused { get; private set; }
    }
}