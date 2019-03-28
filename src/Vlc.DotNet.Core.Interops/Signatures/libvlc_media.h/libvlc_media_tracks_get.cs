using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get media descriptor's elementary streams description.
    /// </summary>
    [LibVlcFunction("libvlc_media_tracks_get")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate uint GetMediaTracks(IntPtr mediaInstance, out IntPtr tracksPointerArray);

    /// <summary>
    /// Release media descriptor's elementary streams description array.
    /// </summary>
    [LibVlcFunction("libvlc_media_tracks_release")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void ReleaseMediaTracks(IntPtr tracksPointerArray, uint tracksCount);
}
