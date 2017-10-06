using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Callback prototype to configure picture buffers format.
    /// </summary>
    /// <param name="userData">
    /// A private pointer as passed to <see cref="SetVideoCallbacks"/>
    /// (and possibly modified by <see cref="VideoFormatCallback"/>
    /// </param>
    [LibVlcFunction("libvlc_video_cleanup_cb")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void CleanupVideoCallback(ref IntPtr userData);
}
