using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Callback prototype to unlock a picture buffer.
    /// When the video frame decoding is complete, the unlock callback is invoked.
    /// This callback might not be needed at all.It is only an indication that the
    /// application can now read the pixel values if it needs to.
    /// </summary>
    /// <remarks>
    /// A picture buffer is unlocked after the picture is decoded,
    /// but before the picture is displayed.
    /// </remarks>
    /// <param name="userData">
    /// private pointer as passed to <see cref="SetVideoCallbacks"/>.
    /// </param>
    /// <param name="picture">
    /// private pointer returned from the <see cref="LockVideoCallback"/>
    /// callback
    /// </param>
    /// <param name="planes">
    /// pixel planes as defined by the <see cref="LockVideoCallback"/>
    /// callback (this parameter is only for convenience)
    /// 
    /// Its size is always PICTURE_PLANE_MAX, which is 5 in my experience. Only the number of planes required by chroma are usable, which is 1 for RV32.
    /// </param>
    [LibVlcFunction("libvlc_video_lock_cb")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void UnlockVideoCallback(IntPtr userData, IntPtr picture, [MarshalAs(UnmanagedType.LPArray, SizeConst = 5)]IntPtr[] planes);
}
