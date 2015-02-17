using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Toggle mute status.
    /// </summary>
    [LibVlcFunction("libvlc_audio_toggle_mute")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void ToggleMute(IntPtr mediaPlayerInstance);
}
