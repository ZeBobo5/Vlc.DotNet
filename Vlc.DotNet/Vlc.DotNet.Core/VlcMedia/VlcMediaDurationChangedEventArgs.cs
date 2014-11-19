using System;

namespace Vlc.DotNet.Core
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