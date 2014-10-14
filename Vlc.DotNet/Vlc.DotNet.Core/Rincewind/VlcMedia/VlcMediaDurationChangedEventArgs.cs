using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public class VlcMediaDurationChangedEventArgs : EventArgs
    {
        public long NewDuration { get; private set; }

        public VlcMediaDurationChangedEventArgs(long newDuration)
        {
            NewDuration = newDuration;
        }
    }
}
