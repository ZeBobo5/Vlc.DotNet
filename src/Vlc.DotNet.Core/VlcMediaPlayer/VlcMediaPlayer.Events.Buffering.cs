using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerBufferingInternalEventCallback;
        public event EventHandler<VlcMediaPlayerBufferingEventArgs> Buffering;

        private void OnMediaPlayerBufferingInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerBuffering(args.eventArgsUnion.MediaPlayerBuffering.NewCache);
        }

        public void OnMediaPlayerBuffering(float newCache)
        {
            Buffering?.Invoke(this, new VlcMediaPlayerBufferingEventArgs(newCache));
        }
    }
}