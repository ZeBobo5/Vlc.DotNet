using System;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public class VlcMediaStateChangedEventArgs : EventArgs
    {
        public MediaStates State { get; private set; }

        public VlcMediaStateChangedEventArgs(MediaStates state)
        {
            State = state;
        }
    }
}
