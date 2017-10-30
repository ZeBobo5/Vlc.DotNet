using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Release a list of module descriptions.
    /// </summary>
    [LibVlcFunction("libvlc_module_description_list_release")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void ReleaseModuleDescription(IntPtr moduleDescription);
}
