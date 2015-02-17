using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Set the audio output. Change will be applied after stop and play.
    /// </summary>
    [LibVlcFunction("libvlc_audio_output_set")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetAudioOutput(IntPtr mediaPlayerInstance, IntPtr audioOutputName);
}
