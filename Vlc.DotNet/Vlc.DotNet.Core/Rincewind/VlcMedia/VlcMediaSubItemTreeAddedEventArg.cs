using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public class VlcMediaSubItemTreeAddedEventArgs : EventArgs
    {
        public VlcMediaSubItemTreeAddedEventArgs(VlcMedia subItemTreeAdded)
        {
            SubItemTreeAdded = subItemTreeAdded;
        }

        public VlcMedia SubItemTreeAdded { get; private set; }
    }
}