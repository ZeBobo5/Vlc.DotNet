using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetVideoLogoEnabled(VlcMediaPlayerInstance mediaPlayerInstance, bool value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.Enable, value ? 1 : 0);
        }
        public void SetVideoLogoFile(VlcMediaPlayerInstance mediaPlayerInstance, string value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
#if NET20
            GetInteropDelegate<SetVideoLogoString>().Invoke(mediaPlayerInstance, VideoLogoOptions.File, StringExtensions.ToHGlobalAnsi(value));
#else
            GetInteropDelegate<SetVideoLogoString>().Invoke(mediaPlayerInstance, VideoLogoOptions.File, value.ToHGlobalAnsi());
#endif
        }
        public void SetVideoLogoX(VlcMediaPlayerInstance mediaPlayerInstance, int value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.X, value);
        }
        public void SetVideoLogoY(VlcMediaPlayerInstance mediaPlayerInstance, int value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.Y, value);
        }
        public void SetVideoLogoDelay(VlcMediaPlayerInstance mediaPlayerInstance, int value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.Delay, value);
        }
        public void SetVideoLogoRepeat(VlcMediaPlayerInstance mediaPlayerInstance, int value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.Repeat, value);
        }
        public void SetVideoLogoOpacity(VlcMediaPlayerInstance mediaPlayerInstance, int value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.Opacity, value);
        }
        public void SetVideoLogoPosition(VlcMediaPlayerInstance mediaPlayerInstance, int value)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetVideoLogoInteger>().Invoke(mediaPlayerInstance, VideoLogoOptions.Position, value);
        }
    }
}
