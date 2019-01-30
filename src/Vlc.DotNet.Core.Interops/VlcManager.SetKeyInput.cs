using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        /// <summary>
        /// Enables/Disables libvlc's handling of keyboard input
        /// </summary>
        /// <param name="mediaPlayerInstance">The media player instance</param>
        /// <param name="on"><c>true</c> if libvlc should handle keyboard events, <c>false</c> otherwise</param>
        /// <remarks>Must be called before the stream has started playing. This is not applicable to the WPF control.</remarks>
        public void SetKeyInput(VlcMediaPlayerInstance mediaPlayerInstance, bool on)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            myLibraryLoader.GetInteropDelegate<SetKeyInput>().Invoke(mediaPlayerInstance, on ? 1u : 0u);
        }
    }
}