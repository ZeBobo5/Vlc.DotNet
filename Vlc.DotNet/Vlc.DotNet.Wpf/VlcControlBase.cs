using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Vlc.DotNet.Core.Interops;

namespace Vlc.DotNet.Wpf
{
    public abstract class VlcControlBase<T> : HwndHost 
        where T : IDisposable, System.Windows.Forms.IWin32Window, new()
    {
        public T MediaPlayer { get; private set; }

        protected VlcControlBase()
        {
            MediaPlayer = new T();
        }

        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            Win32Interops.SetParent(MediaPlayer.Handle, hwndParent.Handle);
            return new HandleRef(this, MediaPlayer.Handle);
        }

        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            if (EqualityComparer<T>.Default.Equals(MediaPlayer, default(T)))
                return;
            Win32Interops.SetParent(IntPtr.Zero, hwnd.Handle);
            MediaPlayer.Dispose();
            MediaPlayer = default(T);
        }
    }
}