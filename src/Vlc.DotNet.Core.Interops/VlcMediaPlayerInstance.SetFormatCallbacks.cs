using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcMediaPlayerInstance
    {
        [Obsolete]
        public void SetVideoFormatCallbacks(VideoFormatCallback videoFormatCallback, CleanupVideoCallback cleanupCallback)
        {
            myManager.SetVideoFormatCallbacks(this, videoFormatCallback, cleanupCallback);
        }
    }
}
