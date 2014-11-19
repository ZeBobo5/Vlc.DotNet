using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Toggle pause (no effect if there is no media).
    /// </summary>
    [LibVlcFunction("libvlc_media_player_pause")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void Pause(IntPtr mediaPlayerInstance);
}
