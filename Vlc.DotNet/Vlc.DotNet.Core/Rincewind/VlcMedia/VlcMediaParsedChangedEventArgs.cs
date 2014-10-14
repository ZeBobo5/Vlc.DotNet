using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public class VlcMediaParsedChangedEventArgs : EventArgs
    {
        public int NewStatus { get; private set; }

        public VlcMediaParsedChangedEventArgs(int newStatus)
        {
            NewStatus = newStatus;
        }
    }
}
