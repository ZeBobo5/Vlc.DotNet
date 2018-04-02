﻿using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    ///  Get id name of device.
    /// </summary>
    [LibVlcFunction("libvlc_audio_output_device_id")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [Obsolete("Use GetAudioOutputDeviceList instead")]
    internal delegate IntPtr GetAudioOutputDeviceName(IntPtr instance, Utf8StringHandle audioOutputName, int deviceIndex);
}
