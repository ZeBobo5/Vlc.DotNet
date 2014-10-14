using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerVideoOutChangedEventArgs : EventArgs
    {
        public int NewCount { get; private set; }

        public VlcMediaPlayerVideoOutChangedEventArgs(int newCount)
        {
            NewCount = newCount;
        }
    }
}
