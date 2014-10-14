using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerScrambledChangedEventArgs : EventArgs
    {
        public int NewScrambled { get; private set; }

        public VlcMediaPlayerScrambledChangedEventArgs(int newScrambled)
        {
            NewScrambled = newScrambled;
        }
    }
}
