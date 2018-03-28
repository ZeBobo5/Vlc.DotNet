using System;

namespace Vlc.DotNet.Core
{
    public class VlcMediaPlayerAudioVolumeEventArgs : EventArgs
    {
        private float Volume { get; }

        public VlcMediaPlayerAudioVolumeEventArgs(float volume)
        {
            this.Volume = volume;
        }
    }
}