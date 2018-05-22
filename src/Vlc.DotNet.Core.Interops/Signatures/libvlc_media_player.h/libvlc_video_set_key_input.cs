using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Set current key input status.
    /// </summary>
    [LibVlcFunction("libvlc_video_set_key_input")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetKeyInput(IntPtr mediaPlayerInstance, uint status);
}