using System;

namespace Vlc.DotNet.Core
{
    /// <summary>
    /// The event that is emited on a libvlc <c>AudioDevice</c> event
    /// </summary>
    public class VlcMediaPlayerAudioDeviceEventArgs : EventArgs
    {
        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="audioDevice">The audio device</param>
        public VlcMediaPlayerAudioDeviceEventArgs(string audioDevice)
        {
            this.Device = audioDevice;
        }

        /// <summary>
        /// The device
        /// </summary>
        public string Device { get; }
    }
}