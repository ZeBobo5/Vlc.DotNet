using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerScrambledChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerScrambledChangedEventArgs> ScrambledChanged;

        private void OnMediaPlayerScrambledChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerScrambledChanged(args.eventArgsUnion.MediaPlayerScrambledChanged.NewScrambled);
        }

        public void OnMediaPlayerScrambledChanged(int newScrambled)
        {
            ScrambledChanged?.Invoke(this, new VlcMediaPlayerScrambledChangedEventArgs(newScrambled));
        }
    }
}