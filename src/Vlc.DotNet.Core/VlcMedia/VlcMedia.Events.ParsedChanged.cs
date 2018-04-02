using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public partial class VlcMedia
    {
        private EventCallback myOnMediaParsedChangedInternalEventCallback;
        public event EventHandler<VlcMediaParsedChangedEventArgs> ParsedChanged;

        private void OnMediaParsedChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaParsedChanged(args.eventArgsUnion.MediaParsedChanged.NewStatus);
        }

        public void OnMediaParsedChanged(int newStatus)
        {
            ParsedChanged?.Invoke(this, new VlcMediaParsedChangedEventArgs(newStatus));
        }
    }
}