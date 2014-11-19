using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Set a Win32/Win64 API window handle (HWND) where the media player should render its video output. If LibVLC was built without Win32/Win64 API output support, then this has no effects.
    /// </summary>
    [LibVlcFunction("libvlc_media_player_set_hwnd")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetMediaPlayerVideoHostHandle(IntPtr mediaPlayerInstance, IntPtr videoHostHandle);
}
