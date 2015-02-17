using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get media fps rate.
    /// </summary>
    [LibVlcFunction("libvlc_media_player_get_fps")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate float GetFramesPerSecond(IntPtr mediaPlayerInstance);
}
