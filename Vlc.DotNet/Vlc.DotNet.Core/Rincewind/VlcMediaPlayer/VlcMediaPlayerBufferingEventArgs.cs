using System;

namespace Vlc.DotNet.Core.Rincewind
{
    public sealed class VlcMediaPlayerBufferingEventArgs : EventArgs
    {
        public float NewCache { get; private set; }

        public VlcMediaPlayerBufferingEventArgs(float newCache)
        {
            NewCache = newCache;
        }
    }
}
