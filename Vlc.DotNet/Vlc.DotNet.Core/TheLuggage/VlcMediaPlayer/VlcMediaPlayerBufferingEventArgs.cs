using System;

namespace Vlc.DotNet.Core.TheLuggage
{
    public sealed class VlcMediaPlayerBufferingEventArgs : EventArgs
    {
        public VlcMediaPlayerBufferingEventArgs(float newCache)
        {
            NewCache = newCache;
        }

        public float NewCache { get; private set; }
    }
}