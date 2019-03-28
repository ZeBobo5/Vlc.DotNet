using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Gets a list of audio output devices for a given audio output module
    /// </summary>
    [LibVlcFunction("libvlc_audio_output_device_list_get")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr GetAudioOutputDeviceList(IntPtr instance, Utf8StringHandle aout);

    /// <summary>
    /// Frees a list of available audio output devices.
    /// </summary>
    [LibVlcFunction("libvlc_audio_output_device_list_release")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr ReleaseAudioOutputDeviceList(IntPtr deviceList);
}
