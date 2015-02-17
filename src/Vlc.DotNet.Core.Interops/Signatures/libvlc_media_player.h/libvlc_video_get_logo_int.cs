using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get integer logo option.
    /// </summary>
    [LibVlcFunction("libvlc_video_get_logo_int")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int GetVideoLogoInteger(IntPtr mediaPlayerInstance, VideoLogoOptions option);
}
