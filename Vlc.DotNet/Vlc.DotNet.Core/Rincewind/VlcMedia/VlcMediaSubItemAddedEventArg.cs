using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public class VlcMediaSubItemAddedEventArgs : EventArgs
    {
        public VlcMedia SubItemAdded { get; private set; }

        public VlcMediaSubItemAddedEventArgs(VlcMedia subItemAdded)
        {
            SubItemAdded = subItemAdded;
        }
    }
}
