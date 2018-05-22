using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Set current mouse input status.
    /// </summary>
    [LibVlcFunction("libvlc_video_set_mouse_input")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetMouseInput(IntPtr mediaPlayerInstance, uint status);
}