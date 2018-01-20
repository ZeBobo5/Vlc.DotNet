using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Callback prototype to allocate and lock a picture buffer.
    /// </summary>
    /// <param name="userData">
    /// Private pointer as passed to <see cref="SetVideoCallbacks"/>.
    /// </param>
    /// <param name="planes">
    /// The pointer to the array of pointers to the pixel planes (LibVLC allocates the array
    /// of pointers, this callback must initialize the array)
    /// If you only need the first plane, then you have to initialize the address pointed by planes
    /// </param>
    /// <remarks>
    /// Whenever a new video frame needs to be decoded, the lock callback is
    /// invoked.Depending on the video chroma, one or three pixel planes of
    /// adequate dimensions must be returned via the second parameter.Those
    /// planes must be aligned on 32-bytes boundaries.
    /// </remarks>
    [LibVlcFunction("libvlc_video_lock_cb")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr LockVideoCallback(IntPtr userData, IntPtr planes);
}
