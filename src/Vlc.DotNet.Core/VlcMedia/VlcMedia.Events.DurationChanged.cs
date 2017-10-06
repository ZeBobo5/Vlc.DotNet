using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public partial class VlcMedia
    {
        public event EventHandler<VlcMediaDurationChangedEventArgs> DurationChanged;

        private void OnMediaDurationChangedInternal(IntPtr ptr)
        {
#if NET20 || NET35 || NET40 || NET45
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = Marshal.PtrToStructure<VlcEventArg>(ptr);
#endif
            OnMediaDurationChanged(args.eventArgsUnion.MediaDurationChanged.NewDuration);
        }

        public void OnMediaDurationChanged(long newDuration)
        {
            DurationChanged?.Invoke(this, new VlcMediaDurationChangedEventArgs(newDuration));
        }
    }
}