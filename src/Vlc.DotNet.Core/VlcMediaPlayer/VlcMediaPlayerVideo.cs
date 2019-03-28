using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    using System;

    public sealed partial class VlcMediaPlayer
    {
        private LockVideoCallback _lockVideoCallbackReference;
        private UnlockVideoCallback _unlockVideoCallbackReference;
        private DisplayVideoCallback _displayVideoCallbackReference;
        private VideoFormatCallback _videoFormatCallbackReference;
        private CleanupVideoCallback _cleanupCallbackReference;

        /// <summary>
        /// Sets the video callbacks to render decoded video to a custom area in memory.
        /// The media player will hold a reference on the IVideoCallbacks parameter
        /// </summary>
        /// <remarks>
        /// Rendering video into custom memory buffers is considerably less efficient than rendering in a custom window as normal.
        /// See libvlc_video_set_callbacks for detailed explanations
        /// </remarks>
        /// <param name="lockVideo">
        /// Callback to lock video memory (must not be NULL)
        /// </param>
        /// <param name="unlockVideo">
        /// Callback to unlock video memory (or NULL if not needed)
        /// </param>
        /// <param name="display">
        /// Callback to display video (or NULL if not needed)
        /// </param>
        /// <param name="userData">
        /// Private pointer for the three callbacks (as first parameter).
        /// This parameter will be overriden if <see cref="SetVideoFormatCallbacks"/> is used
        /// </param>
        public void SetVideoCallbacks(LockVideoCallback lockVideo, UnlockVideoCallback unlockVideo, DisplayVideoCallback display, IntPtr userData)
        {
            if (lockVideo == null)
            {
                throw new ArgumentNullException(nameof(lockVideo));
            }

            this._lockVideoCallbackReference = lockVideo;
            this._unlockVideoCallbackReference = unlockVideo;
            this._displayVideoCallbackReference = display;

            this.Manager.SetVideoCallbacks(this.myMediaPlayerInstance, this._lockVideoCallbackReference, this._unlockVideoCallbackReference, this._displayVideoCallbackReference, userData);
        }

        /// <summary>
        /// Set decoded video chroma and dimensions. This only works in combination with
        /// <see cref="SetVideoCallbacks" />
        /// </summary>
        /// <param name="videoFormat">Callback to select the video format (cannot be NULL)</param>
        /// <param name="cleanup">Callback to release any allocated resources (or NULL)</param>
        public void SetVideoFormatCallbacks(VideoFormatCallback videoFormat, CleanupVideoCallback cleanup)
        {
            if (videoFormat == null)
            {
                throw new ArgumentNullException(nameof(videoFormat));
            }

            this._videoFormatCallbackReference = videoFormat;
            this._cleanupCallbackReference = cleanup;

            this.Manager.SetVideoFormatCallbacks(this.myMediaPlayerInstance, this._videoFormatCallbackReference, this._cleanupCallbackReference);
        }
    }
}