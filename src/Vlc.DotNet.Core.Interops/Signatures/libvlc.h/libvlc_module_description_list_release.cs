using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Returns a list of audio filters that are available.
    /// </summary>
    [LibVlcFunction("libvlc_module_description_list_release")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void ReleaseModuleDescription(IntPtr moduleDescription);
}
