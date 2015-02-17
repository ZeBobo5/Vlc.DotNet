using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get current audio delay.
    /// </summary>
    [LibVlcFunction("libvlc_audio_get_delay")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate long GetAudioDelay(IntPtr mediaPlayerInstance);
}
