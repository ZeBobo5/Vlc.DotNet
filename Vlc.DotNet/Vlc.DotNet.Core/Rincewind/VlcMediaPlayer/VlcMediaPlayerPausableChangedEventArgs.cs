using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerPausableChangedEventArgs : EventArgs
    {
        public bool IsPaused { get; private set; }

        public VlcMediaPlayerPausableChangedEventArgs(bool paused)
        {
            IsPaused = paused;
        }
    }
}
