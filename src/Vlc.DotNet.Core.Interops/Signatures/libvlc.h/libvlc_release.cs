using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Destroy libvlc instance.
    /// </summary>
    [LibVlcFunction("libvlc_release")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void ReleaseInstance(IntPtr instance);
}
