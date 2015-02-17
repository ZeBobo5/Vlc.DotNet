using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get current mute status.
    /// </summary>
    [LibVlcFunction("libvlc_audio_get_mute")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int IsMute(IntPtr mediaPlayerInstance);
}
