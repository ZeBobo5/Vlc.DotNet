using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Create and initialize a libvlc instance.
    /// </summary>
    /// <returns>Return the libvlc instance or NULL in case of error.</returns>
    [LibVlcFunction("libvlc_new")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr CreateNewInstance(int argc, string[] argv);
}
