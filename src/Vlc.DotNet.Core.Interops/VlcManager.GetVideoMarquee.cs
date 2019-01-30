using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public bool GetVideoMarqueeEnabled(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return myLibraryLoader.GetInteropDelegate<GetVideoMarqueeInteger>().Invoke(mediaPlayerInstance, VideoMarqueeOptions.Enable) == 1;
        }
        public string GetVideoMarqueeText(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return Utf8InteropStringConverter.Utf8InteropToString(myLibraryLoader.GetInteropDelegate<GetVideoMarqueeString>().Invoke(mediaPlayerInstance, VideoMarqueeOptions.Text));
        }
        public int GetVideoMarqueeColor(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return myLibraryLoader.GetInteropDelegate<GetVideoMarqueeInteger>().Invoke(mediaPlayerInstance, VideoMarqueeOptions.Color);
        }
        public int GetVideoMarqueeOpacity(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return myLibraryLoader.GetInteropDelegate<GetVideoMarqueeInteger>().Invoke(mediaPlayerInstance, VideoMarqueeOptions.Opacity);
        }
        public int GetVideoMarqueePosition(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return myLibraryLoader.GetInteropDelegate<GetVideoMarqueeInteger>().Invoke(mediaPlayerInstance, VideoMarqueeOptions.Position);
        }
        public int GetVideoMarqueeRefresh(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return myLibraryLoader.GetInteropDelegate<GetVideoMarqueeInteger>().Invoke(mediaPlayerInstance, VideoMarqueeOptions.Refresh);
        }
        public int GetVideoMarqueeSize(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return myLibraryLoader.GetInteropDelegate<GetVideoMarqueeInteger>().Invoke(mediaPlayerInstance, VideoMarqueeOptions.Size);
        }
        public int GetVideoMarqueeTimeout(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return myLibraryLoader.GetInteropDelegate<GetVideoMarqueeInteger>().Invoke(mediaPlayerInstance, VideoMarqueeOptions.Timeout);
        }
        public int GetVideoMarqueeX(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return myLibraryLoader.GetInteropDelegate<GetVideoMarqueeInteger>().Invoke(mediaPlayerInstance, VideoMarqueeOptions.X);
        }
        public int GetVideoMarqueeY(VlcMediaPlayerInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            return myLibraryLoader.GetInteropDelegate<GetVideoMarqueeInteger>().Invoke(mediaPlayerInstance, VideoMarqueeOptions.Y);
        }
    }
}
