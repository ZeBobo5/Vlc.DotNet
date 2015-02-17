using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Retrieve libvlc version.
    /// </summary>
    /// <returns>Return a string containing the libvlc version.</returns>
    [LibVlcFunction("libvlc_get_version")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr GetVersion();
}
