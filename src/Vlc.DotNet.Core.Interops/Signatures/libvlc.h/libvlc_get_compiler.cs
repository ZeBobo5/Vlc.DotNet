using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Retrieve libvlc compiler version.
    /// </summary>
    /// <returns>Return a string containing the libvlc compiler version.</returns>
    [LibVlcFunction("libvlc_get_compiler")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr GetCompiler();
}
