using System;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerTimeChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerTimeChangedEventArgs> TimeChanged;

        private void OnMediaPlayerTimeChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerTimeChanged(args.eventArgsUnion.MediaPlayerTimeChanged.NewTime);
        }

        public void OnMediaPlayerTimeChanged(long newTime)
        {
            TimeChanged?.Invoke(this, new VlcMediaPlayerTimeChangedEventArgs(newTime));
        }
    }
}