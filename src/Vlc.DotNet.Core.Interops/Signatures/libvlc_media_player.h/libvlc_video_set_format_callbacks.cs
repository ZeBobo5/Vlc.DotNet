using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Set decoded video chroma and dimensions. This only works in combination with
    /// libvlc_video_set_callbacks().
    /// </summary>
    /// <param name="mp">
    /// The media player
    /// </param>
    /// <param name="setup">
    /// Callback to select the video format (cannot be NULL)
    /// </param>
    /// <param name="cleanup">
    /// callback to release any allocated resources (or NULL)
    /// </param>
    [LibVlcFunction("libvlc_video_set_format_callbacks")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetVideoFormatCallbacks(IntPtr mp, VideoFormatCallback setup, CleanupVideoCallback cleanup);
}
