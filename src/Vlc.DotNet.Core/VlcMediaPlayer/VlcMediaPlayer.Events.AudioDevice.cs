using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerAudioDeviceInternalEventCallback;
        public event EventHandler<VlcMediaPlayerAudioDeviceEventArgs> AudioDevice;

        private void OnMediaPlayerAudioDeviceInternal(IntPtr ptr)
        {
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            OnMediaPlayerAudioDevice(Utf8InteropStringConverter.Utf8InteropToString(args.eventArgsUnion.MediaPlayerAudioDevice.pszDevice));
        }

        public void OnMediaPlayerAudioDevice(string audioDevice)
        {
            AudioDevice?.Invoke(this, new VlcMediaPlayerAudioDeviceEventArgs(audioDevice));
        }
    }
}