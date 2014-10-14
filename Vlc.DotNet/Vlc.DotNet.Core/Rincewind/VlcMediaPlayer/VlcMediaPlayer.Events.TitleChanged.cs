using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Rincewind
{
    public partial class VlcMediaPlayer
    {
        public event EventHandler<VlcMediaPlayerTitleChangedEventArgs> TitleChanged;

        private EventCallback myOnMediaPlayerTitleChangedInternalEventCallback;

        private void OnMediaPlayerTitleChangedInternal(IntPtr ptr)
        {
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
            var fileName = Marshal.PtrToStringAnsi(args.MediaPlayerTitleChanged.NewTitle);
            OnMediaPlayerTitleChanged(fileName);
        }

        public void OnMediaPlayerTitleChanged(string fileName)
        {
            var del = TitleChanged;
            if (del != null)
                del(this, new VlcMediaPlayerTitleChangedEventArgs(fileName));
        }
    }
}
