using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMedia
    {
        public event EventHandler<VlcMediaFreedEventArgs> Freed;

        private EventCallback myOnMediaFreedInternalEventCallback;

        private void OnMediaFreedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
            //OnMediaFreed(args.MediaFreed.MediaInstance);
            OnMediaFreed();
        }

        public void OnMediaFreed()
        {
            var del = Freed;
            if (del != null)
                del(this, new VlcMediaFreedEventArgs());
        }
    }
}
