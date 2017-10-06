using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Callback prototype to display a picture.
    /// When the video frame needs to be shown, as determined by the media playback
    /// clock, the display callback is invoked.
    /// </summary>
    /// <param name="userData">
    /// Private pointer as passed to <see cref="SetVideoCallbacks"/>
    /// </param>
    /// <param name="picture">
    /// Private pointer returned from <see cref="LockVideoCallback"/>.
    /// </param>
    [LibVlcFunction("libvlc_video_display_cb")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DisplayVideoCallback(IntPtr userData, IntPtr picture);
}
