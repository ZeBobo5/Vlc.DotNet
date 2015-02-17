using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetMediaChapter(VlcMediaPlayerInstance mediaPlayerInstance, int chapter)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetMediaChapter>().Invoke(mediaPlayerInstance, chapter);
        }
    }
}
