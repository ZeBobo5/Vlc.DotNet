using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get the Windows API window handle (HWND) previously set.
    /// </summary>
    [LibVlcFunction("libvlc_media_player_get_hwnd")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr GetMediaPlayerVideoHostHandle(IntPtr mediaPlayerInstance);
}
