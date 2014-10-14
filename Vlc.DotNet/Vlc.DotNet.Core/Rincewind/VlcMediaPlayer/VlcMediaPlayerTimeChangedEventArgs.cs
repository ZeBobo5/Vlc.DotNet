using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerTimeChangedEventArgs : EventArgs
    {
        public long NewTime { get; private set; }

        public VlcMediaPlayerTimeChangedEventArgs(long newTime)
        {
            NewTime = newTime;
        }
    }
}
