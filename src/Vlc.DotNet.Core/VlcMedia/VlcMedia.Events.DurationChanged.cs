using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public partial class VlcMedia
    {
        public event EventHandler<VlcMediaDurationChangedEventArgs> DurationChanged;

        private void OnMediaDurationChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaDurationChanged(args.eventArgsUnion.MediaDurationChanged.NewDuration);
        }

        public void OnMediaDurationChanged(long newDuration)
        {
            DurationChanged?.Invoke(this, new VlcMediaDurationChangedEventArgs(newDuration));
        }
    }
}