using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMediaPlayer
    {
        public event EventHandler<VlcMediaPlayerScrambledChangedEventArgs> ScrambledChanged;

        private EventCallback myOnMediaPlayerScrambledChangedInternalEventCallback;

        private void OnMediaPlayerScrambledChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
            OnMediaPlayerScrambledChanged(args.MediaPlayerScrambledChanged.NewScrambled);
        }

        public void OnMediaPlayerScrambledChanged(int newScrambled)
        {
            var del = ScrambledChanged;
            if (del != null)
                del(this, new VlcMediaPlayerScrambledChangedEventArgs(newScrambled));
        }
    }
}
