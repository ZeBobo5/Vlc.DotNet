using System;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcTheLuggageManager
    {
        public void SetMediaToMediaPlayer(IntPtr mediaPlayerInstance, IntPtr mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetMediaToMediaPlayer>().Invoke(mediaPlayerInstance, mediaInstance);
        }
    }
}
