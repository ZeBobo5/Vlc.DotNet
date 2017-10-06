using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcMediaPlayerInstance
    {
        public void SetVideoFormatCallbacks(VideoFormatCallback videoFormatCallback, CleanupVideoCallback cleanupCallback)
        {
            myManager.GetInteropDelegate<SetVideoFormatCallbacks>().Invoke(this.Pointer, videoFormatCallback, cleanupCallback);
        }
    }
}
