using System;

namespace Vlc.DotNet.Core
{
    public sealed class VlcMediaPlayerVideoOutChangedEventArgs : EventArgs
    {
        public VlcMediaPlayerVideoOutChangedEventArgs(int newCount)
        {
            NewCount = newCount;
        }

        public int NewCount { get; private set; }
    }
}