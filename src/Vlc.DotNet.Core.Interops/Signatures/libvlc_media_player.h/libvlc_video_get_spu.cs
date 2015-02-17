using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get current video subtitle.
    /// </summary>
    [LibVlcFunction("libvlc_video_get_spu")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int GetVideoSpu(IntPtr mediaPlayerInstance);
}
