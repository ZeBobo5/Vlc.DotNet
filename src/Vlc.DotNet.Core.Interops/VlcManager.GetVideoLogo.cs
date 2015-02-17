using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public bool GetVideoLogoEnabled(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.Enable) == 1;
        }

        public int GetVideoLogoX(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.X);
        }
        public int GetVideoLogoY(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.Y);
        }
        public int GetVideoLogoDelay(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.Delay);
        }
        public int GetVideoLogoRepeat(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.Repeat);
        }
        public int GetVideoLogoOpacity(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.Opacity);
        }
        public int GetVideoLogoPosition(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return GetInteropDelegate<GetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.Position);
        }
    }
}
