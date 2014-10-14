using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public class VlcMediaSubItemTreeAddedEventArgs : EventArgs
    {
        public VlcMedia SubItemTreeAdded { get; private set; }

        public VlcMediaSubItemTreeAddedEventArgs(VlcMedia subItemTreeAdded)
        {
            SubItemTreeAdded = subItemTreeAdded;
        }
    }
}
