using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// It will release the libvlc_track_description_t object.
    /// </summary>
    [LibVlcFunction("libvlc_track_description_list_release")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void ReleaseTrackDescription(TrackDescriptionStructure trackDescription);
}
