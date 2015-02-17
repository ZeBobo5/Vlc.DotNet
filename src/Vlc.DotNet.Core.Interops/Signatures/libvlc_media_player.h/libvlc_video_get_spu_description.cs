using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get the description of available video subtitles.
    /// </summary>
    [LibVlcFunction("libvlc_video_get_spu_description")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate TrackDescriptionStructure GetVideoSpuDescription(IntPtr mediaPlayerInstance);
}
