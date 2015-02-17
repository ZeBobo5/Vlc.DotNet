using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Set logo option as string.
    /// </summary>
    [LibVlcFunction("libvlc_video_set_logo_string")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetVideoLogoString(IntPtr mediaPlayerInstance, VideoLogoOptions option, IntPtr value);
}
