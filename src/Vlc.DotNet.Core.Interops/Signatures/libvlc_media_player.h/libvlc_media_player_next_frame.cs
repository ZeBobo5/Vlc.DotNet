using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Display the next frame (if supported).
    /// </summary>
    [LibVlcFunction("libvlc_media_player_next_frame")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void NextFrame(IntPtr mediaPlayerInstance);
}
