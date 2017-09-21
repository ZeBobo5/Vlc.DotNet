using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Set callbacks and private data to render decoded video to a custom area
    /// in memory.
    /// Use <see cref="SetVideoFormatCallbacks"/> to configure the decoded format.
    /// </summary>
    /// <param name="mp">
    /// The media player.
    /// </param>
    /// <param name="lockCallback">
    /// Callback to lock video memory (must not be NULL)
    /// </param>
    /// <param name="unlockCallback">
    /// Callback to unlock video memory (or NULL if not needed)
    /// </param>
    /// <param name="displayCallback">
    /// Callback to display video (or NULL if not needed)
    /// </param>
    /// <param name="userData">
    /// Private pointer for the three callbacks (as first parameter)
    /// </param>
    [LibVlcFunction("libvlc_video_set_callbacks")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetVideoCallbacks(IntPtr mp, LockVideoCallback lockCallback, UnlockVideoCallback unlockCallback, DisplayVideoCallback displayCallback, IntPtr userData);
}
