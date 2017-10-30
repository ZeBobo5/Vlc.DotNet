using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Returns a list of audio filters that are available.
    /// </summary>
    [LibVlcFunction("libvlc_audio_filter_list_get")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr GetAudioFilterList(IntPtr instance);
}
