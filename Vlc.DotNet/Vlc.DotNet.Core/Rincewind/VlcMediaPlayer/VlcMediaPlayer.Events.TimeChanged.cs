using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMediaPlayer
    {
        public event EventHandler<VlcMediaPlayerTimeChangedEventArgs> TimeChanged;

        private EventCallback myOnMediaPlayerTimeChangedInternalEventCallback;

        private void OnMediaPlayerTimeChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
            OnMediaPlayerTimeChanged(args.MediaPlayerTimeChanged.NewTime);
        }

        public void OnMediaPlayerTimeChanged(long newTime)
        {
            var del = TimeChanged;
            if (del != null)
                del(this, new VlcMediaPlayerTimeChangedEventArgs(newTime));
        }
    }
}
