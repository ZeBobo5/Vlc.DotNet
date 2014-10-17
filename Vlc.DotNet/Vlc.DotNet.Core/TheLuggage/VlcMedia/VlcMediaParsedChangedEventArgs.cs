using System;

namespace Vlc.DotNet.Core.TheLuggage
{
    public class VlcMediaParsedChangedEventArgs : EventArgs
    {
        public VlcMediaParsedChangedEventArgs(int newStatus)
        {
            NewStatus = newStatus;
        }

        public int NewStatus { get; private set; }
    }
}