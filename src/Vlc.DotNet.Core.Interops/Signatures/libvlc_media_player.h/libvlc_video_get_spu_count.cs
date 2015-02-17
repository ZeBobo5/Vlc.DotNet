using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get the number of available video subtitles.
    /// </summary>
    [LibVlcFunction("libvlc_video_get_spu_count")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int GetVideoSpuCount(IntPtr mediaPlayerInstance);
}
