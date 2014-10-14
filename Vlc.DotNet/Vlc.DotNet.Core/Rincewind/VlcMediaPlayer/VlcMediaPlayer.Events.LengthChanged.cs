using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMediaPlayer
    {
        public event EventHandler<VlcMediaPlayerLengthChangedEventArgs> LengthChanged;

        private EventCallback myOnMediaPlayerLengthChangedInternalEventCallback;

        private void OnMediaPlayerLengthChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
            OnMediaPlayerLengthChanged(args.MediaPlayerLengthChanged.NewLength);
        }

        public void OnMediaPlayerLengthChanged(float newLength)
        {
            var del = LengthChanged;
            if (del != null)
                del(this, new VlcMediaPlayerLengthChangedEventArgs(newLength));
        }
    }
}
