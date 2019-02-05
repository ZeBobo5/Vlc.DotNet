using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary> 
    /// Set fullscreen. 
    /// </summary>
    [LibVlcFunction("libvlc_get_fullscreen")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool GetFullScreen(IntPtr mediaPlayerInstance);
}