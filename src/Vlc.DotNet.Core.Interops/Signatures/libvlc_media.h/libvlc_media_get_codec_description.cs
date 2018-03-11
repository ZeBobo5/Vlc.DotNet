using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get codec description from media elementary stream.
    ///  LibVLC 3.0.0 and later.
    /// </summary>
    [LibVlcFunction("libvlc_media_get_codec_description")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr GetCodecDescription(MediaTrackTypes type, UInt32 codec);
}
