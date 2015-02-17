using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get current teletext page requested.
    /// </summary>
    [LibVlcFunction("libvlc_video_get_teletext")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int GetVideoTeletext(IntPtr mediaPlayerInstance);
}
