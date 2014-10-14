using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMediaPlayer
    {
        public event EventHandler<VlcMediaPlayerBufferingEventArgs> Buffering;

        private EventCallback myOnMediaPlayerBufferingInternalEventCallback;

        private void OnMediaPlayerBufferingInternal(IntPtr ptr)
        {
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
            OnMediaPlayerBuffering(args.MediaPlayerBuffering.NewCache);
        }

        public void OnMediaPlayerBuffering(float newCache)
        {
            var del = Buffering;
            if (del != null)
                del(this, new VlcMediaPlayerBufferingEventArgs(newCache));
        }
    }
}
