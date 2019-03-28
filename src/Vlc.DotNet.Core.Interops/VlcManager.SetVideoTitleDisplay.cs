using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        /// <summary>
        /// Set if, and how, the video title will be shown when media is played.
        /// </summary>
        /// <param name="mediaPlayerInstance">The media player instance</param>
        /// <param name="position">position at which to display the title, or libvlc_position_disable to prevent the title from being displayed</param>
        /// <param name="timeout">title display timeout in milliseconds (ignored if libvlc_position_disable)</param>
        public void SetVideoTitleDisplay(IntPtr mediaPlayerInstance, Position position, int timeout)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            myLibraryLoader.GetInteropDelegate<SetVideoTitleDisplay>().Invoke(mediaPlayerInstance, position, timeout);
        }
    }
}