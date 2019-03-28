using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerAudioVolumeInternalEventCallback;
        public event EventHandler<VlcMediaPlayerAudioVolumeEventArgs> AudioVolume;

        private void OnMediaPlayerAudioVolumeInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerAudioVolume(args.eventArgsUnion.MediaPlayerAudioVolume.volume);
        }

        public void OnMediaPlayerAudioVolume(float volume)
        {
            AudioVolume?.Invoke(this, new VlcMediaPlayerAudioVolumeEventArgs(volume));
        }
    }
}