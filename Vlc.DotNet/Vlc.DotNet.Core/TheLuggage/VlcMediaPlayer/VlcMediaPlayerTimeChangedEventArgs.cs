using System;

namespace Vlc.DotNet.Core.TheLuggage
{
    public sealed class VlcMediaPlayerTimeChangedEventArgs : EventArgs
    {
        public VlcMediaPlayerTimeChangedEventArgs(long newTime)
        {
            NewTime = newTime;
        }

        public long NewTime { get; private set; }
    }
}