using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public bool GetVideoAdjustEnabled(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoAdjustInteger>().Invoke(mediaPlayerInstance, VideoAdjustOptions.Enable) == 1;
        }

        public float GetVideoAdjustContrast(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoAdjustFloat>().Invoke(mediaPlayerInstance, VideoAdjustOptions.Contrast);
        }

        public float GetVideoAdjustBrightness(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoAdjustFloat>().Invoke(mediaPlayerInstance, VideoAdjustOptions.Brightness);
        }

        public float GetVideoAdjustHue(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoAdjustFloat>().Invoke(mediaPlayerInstance, VideoAdjustOptions.Hue);
        }

        public float GetVideoAdjustSaturation(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoAdjustFloat>().Invoke(mediaPlayerInstance, VideoAdjustOptions.Saturation);
        }

        public float GetVideoAdjustGamma(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoAdjustFloat>().Invoke(mediaPlayerInstance, VideoAdjustOptions.Gamma);
        }
    }
}
