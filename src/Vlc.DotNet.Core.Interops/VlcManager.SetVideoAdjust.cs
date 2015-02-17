using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetVideoAdjustEnabled(VlcMediaPlayerInstance mediaPlayerInstance, bool value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoAdjustInteger>().Invoke(mediaPlayerInstance, VideoAdjustOptions.Enable, value ? 1 : 0);
        }
        public void SetVideoAdjustContrast(VlcMediaPlayerInstance mediaPlayerInstance, float value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoAdjustFloat>().Invoke(mediaPlayerInstance, VideoAdjustOptions.Contrast, value);
        }
        public void SetVideoAdjustBrightness(VlcMediaPlayerInstance mediaPlayerInstance, float value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoAdjustFloat>().Invoke(mediaPlayerInstance, VideoAdjustOptions.Brightness, value);
        }
        public void SetVideoAdjustHue(VlcMediaPlayerInstance mediaPlayerInstance, float value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoAdjustFloat>().Invoke(mediaPlayerInstance, VideoAdjustOptions.Hue, value);
        }
        public void SetVideoAdjustSaturation(VlcMediaPlayerInstance mediaPlayerInstance, float value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoAdjustFloat>().Invoke(mediaPlayerInstance, VideoAdjustOptions.Saturation, value);
        }
        public void SetVideoAdjustGamma(VlcMediaPlayerInstance mediaPlayerInstance, float value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoAdjustFloat>().Invoke(mediaPlayerInstance, VideoAdjustOptions.Gamma, value);
        }
    }
}
