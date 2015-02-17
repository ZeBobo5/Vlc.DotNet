using System;

namespace Vlc.DotNet.Core
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