using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public partial class VlcMedia
    {
        private EventCallback myOnMediaStateChangedInternalEventCallback;
        public event EventHandler<VlcMediaStateChangedEventArgs> StateChanged;

        private void OnMediaStateChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg) Marshal.PtrToStructure(ptr, typeof (VlcEventArg));
            OnMediaStateChanged(args.MediaStateChanged.NewState);
        }

        public void OnMediaStateChanged(MediaStates state)
        {
            var del = StateChanged;
            if (del != null)
                del(this, new VlcMediaStateChangedEventArgs(state));
        }
    }
}