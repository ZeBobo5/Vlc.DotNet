using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerScrambledChangedEventArgs : EventArgs
    {
        public VlcMediaPlayerScrambledChangedEventArgs(int newScrambled)
        {
            NewScrambled = newScrambled;
        }

        public int NewScrambled { get; private set; }
    }
}