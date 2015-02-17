using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get the description of available audio tracks.
    /// </summary>
    [LibVlcFunction("libvlc_audio_get_track_description")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate TrackDescriptionStructure GetAudioTracksDescriptions(IntPtr mediaPlayerInstance);
}
