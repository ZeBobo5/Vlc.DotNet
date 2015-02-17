using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get current crop filter geometry.
    /// </summary>
    [LibVlcFunction("libvlc_video_get_crop_geometry")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr GetVideoCropGeometry(IntPtr mediaPlayerInstance);
}
