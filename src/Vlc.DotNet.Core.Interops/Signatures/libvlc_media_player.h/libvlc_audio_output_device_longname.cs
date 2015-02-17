using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    ///  Get long name of device, if not available short name given.
    /// </summary>
    [LibVlcFunction("libvlc_audio_output_device_longname")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr GetAudioOutputDeviceLongName(IntPtr instance, IntPtr audioOutputName, int deviceIndex);
}
