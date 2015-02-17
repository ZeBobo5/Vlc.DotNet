using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get count of devices for audio output, these devices are hardware oriented like analor or digital output of sound card.
    /// </summary>
    [LibVlcFunction("libvlc_audio_output_device_count")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int GetAudioOutputDeviceCount(IntPtr instance, string outputName);
}
