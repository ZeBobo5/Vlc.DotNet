using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Set current mute status.
    /// </summary>
    [LibVlcFunction("libvlc_audio_set_mute")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetMute(IntPtr mediaPlayerInstance, int status);
}
