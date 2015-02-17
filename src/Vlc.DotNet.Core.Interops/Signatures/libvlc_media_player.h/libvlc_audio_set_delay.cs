using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Set current audio delay. The audio delay will be reset to zero each time the media changes.
    /// </summary>
    [LibVlcFunction("libvlc_audio_set_delay")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetAudioDelay(IntPtr mediaPlayerInstance, long channel);
}
