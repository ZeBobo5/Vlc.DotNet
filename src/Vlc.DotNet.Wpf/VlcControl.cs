using System;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Interop;
using Vlc.DotNet.Core.Interops;

namespace Vlc.DotNet.Wpf
{
    public class VlcControl : ContentControl 
    {
        class VlcHost : HwndHost
        {
            public Forms.VlcControl MediaPlayer
            { get; set; }

            public VlcHost(Forms.VlcControl mediaPlayer)
            {
                this.MediaPlayer = mediaPlayer;
            }

            protected override HandleRef BuildWindowCore(HandleRef hwndParent)
            {
                Win32Interops.SetParent(MediaPlayer.Handle, hwndParent.Handle);
                return new HandleRef(this, MediaPlayer.Handle);
            }

            protected override void DestroyWindowCore(HandleRef hwnd)
            {
                if (MediaPlayer == null)
                    return;
                Win32Interops.SetParent(IntPtr.Zero, hwnd.Handle);
                MediaPlayer.Dispose();
                MediaPlayer = null;
            }
        }

        public Forms.VlcControl MediaPlayer { get; private set; }

        public VlcControl()
        {
            MediaPlayer = new Forms.VlcControl();
            MediaPlayer.HandleCreated += MediaPlayer_HandleCreated;

            // add the content
            this.Content = new VlcHost(MediaPlayer);
        }

        void MediaPlayer_HandleCreated(object sender, EventArgs e)
        {
            // windows handle changed - need a new host
            this.Content = new VlcHost(MediaPlayer);
        }
    }
}