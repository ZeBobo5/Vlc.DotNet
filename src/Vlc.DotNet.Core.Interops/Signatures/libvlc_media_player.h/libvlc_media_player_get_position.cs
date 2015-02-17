using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get media position.
    /// </summary>
    [LibVlcFunction("libvlc_media_player_get_position")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate float GetMediaPosition(IntPtr mediaPlayerInstance);
}
