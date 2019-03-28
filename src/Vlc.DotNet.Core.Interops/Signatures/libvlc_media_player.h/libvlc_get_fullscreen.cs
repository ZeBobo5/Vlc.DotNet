using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get current fullscreen status. 
    /// </summary>
    [LibVlcFunction("libvlc_get_fullscreen")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int GetFullScreen(IntPtr mediaPlayerInstance);
}