using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Vlc.DotNet.Core.Interops;
using System.Windows.Forms.Integration;

namespace Vlc.DotNet.Wpf
{
    public class VlcControl : WindowsFormsHost
    {
        public Forms.VlcControl MediaPlayer { get; private set; }

        public VlcControl()
        {
            MediaPlayer = new Forms.VlcControl();
            this.Child = MediaPlayer; 
        }
    }
}