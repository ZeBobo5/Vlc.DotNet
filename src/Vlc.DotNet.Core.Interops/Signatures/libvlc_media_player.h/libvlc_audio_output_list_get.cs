using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get the list of available audio outputs.
    /// </summary>
    [LibVlcFunction("libvlc_audio_output_list_get")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate AudioOutputDescriptionStructure GetAudioOutputsDescriptions(IntPtr instance);
}
