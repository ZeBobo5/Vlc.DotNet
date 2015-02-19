using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Take a snapshot of the current video window.
    /// </summary>
    /// <returns>Return 0 on success, -1 if the video was not found.</returns>
    [LibVlcFunction("libvlc_video_take_snapshot")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int TakeSnapshot(IntPtr mediaPlayerInstance, uint num, string fileName, uint width, uint height);
}
