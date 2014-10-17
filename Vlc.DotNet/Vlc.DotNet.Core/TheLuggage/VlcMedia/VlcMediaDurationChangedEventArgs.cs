using System;

namespace Vlc.DotNet.Core.TheLuggage
{
    public class VlcMediaDurationChangedEventArgs : EventArgs
    {
        public VlcMediaDurationChangedEventArgs(long newDuration)
        {
            NewDuration = newDuration;
        }

        public long NewDuration { get; private set; }
    }
}