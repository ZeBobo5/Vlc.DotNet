using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        private VideoFormatCallback _videoFormatCallbackReference;
        private CleanupVideoCallback _cleanupCallbackReference;

        public void SetVideoFormatCallbacks(VlcMediaPlayerInstance mediaPlayerInstance, VideoFormatCallback videoFormatCallback, CleanupVideoCallback cleanupCallback)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");

            this._videoFormatCallbackReference = videoFormatCallback;
            this._cleanupCallbackReference = cleanupCallback;

            GetInteropDelegate<SetVideoFormatCallbacks>().Invoke(mediaPlayerInstance, this._videoFormatCallbackReference, this._cleanupCallbackReference);
        }
    }
}
