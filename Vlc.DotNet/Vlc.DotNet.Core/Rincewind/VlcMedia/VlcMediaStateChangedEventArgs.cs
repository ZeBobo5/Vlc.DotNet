using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
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