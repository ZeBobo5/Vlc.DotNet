using System;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.TheLuggage
{
    public class VlcMediaStateChangedEventArgs : EventArgs
    {
        public VlcMediaStateChangedEventArgs(MediaStates state)
        {
            State = state;
        }

        public MediaStates State { get; private set; }
    }
}