using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMedia
    {
        private EventCallback myOnMediaDurationChangedInternalEventCallback;
        public event EventHandler<VlcMediaDurationChangedEventArgs> DurationChanged;

        private void OnMediaDurationChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg) Marshal.PtrToStructure(ptr, typeof (VlcEventArg));
            OnMediaDurationChanged(args.MediaDurationChanged.NewDuration);
        }

        public void OnMediaDurationChanged(long newDuration)
        {
            var del = DurationChanged;
            if (del != null)
                del(this, new VlcMediaDurationChangedEventArgs(newDuration));
        }
    }
}