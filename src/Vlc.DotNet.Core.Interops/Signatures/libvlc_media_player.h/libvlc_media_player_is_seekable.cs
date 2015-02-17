using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get media is seekable.
    /// </summary>
    [LibVlcFunction("libvlc_media_player_is_seekable")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int IsSeekable(IntPtr mediaPlayerInstance);
}
