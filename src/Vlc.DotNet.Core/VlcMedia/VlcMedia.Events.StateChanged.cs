using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public partial class VlcMedia
    {
        private EventCallback myOnMediaStateChangedInternalEventCallback;
        public event EventHandler<VlcMediaStateChangedEventArgs> StateChanged;

        private void OnMediaStateChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaStateChanged(args.eventArgsUnion.MediaStateChanged.NewState);
        }

        public void OnMediaStateChanged(MediaStates state)
        {
            StateChanged?.Invoke(this, new VlcMediaStateChangedEventArgs(state));
        }
    }
}