using System;

namespace Vlc.DotNet.Core.Rincewind
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