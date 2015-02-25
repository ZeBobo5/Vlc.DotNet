using System;

namespace Vlc.DotNet.Core
{
    public class VlcMediaSubItemAddedEventArgs : EventArgs
    {
        public VlcMediaSubItemAddedEventArgs(VlcMedia subItemAdded)
        {
            SubItemAdded = subItemAdded;
        }

        public VlcMedia SubItemAdded { get; private set; }
    }
}