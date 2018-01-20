using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Callback prototype to configure picture buffers format.
    /// This callback gets the format of the video as output by the video decoder
    /// and the chain of video filters(if any). It can opt to change any parameter
    /// as it needs.In that case, LibVLC will attempt to convert the video format
    /// (rescaling and chroma conversion) but these operations can be CPU intensive.
    /// </summary>
    /// <param name="userData">
    /// pointer to the private pointer passed to <see cref="SetVideoCallbacks"/>.
    /// </param>
    /// <param name="chroma">
    /// A pointer to the 4 bytes video format identifier.
    /// </param>
    /// <param name="width">
    /// A reference to the pixel width.
    /// </param>
    /// <param name="height">
    /// A referebce to the pixel height.
    /// </param>
    /// <param name="pitches">
    /// A reference to the table of scanline pitches in bytes for each pixel plane
    /// (the table is allocated by LibVLC).
    /// </param>
    /// <param name="lines">
    /// A reference to the table of scanlines count for each plane.
    /// </param>
    /// <returns>
    /// The number of picture buffers allocated, 0 indicates failure.
    /// </returns>
    /// <remarks>
    /// For each pixels plane, the scanline pitch must be bigger than or equal to
    /// the number of bytes per pixel multiplied by the pixel width.
    /// Similarly, the number of scanlines must be bigger than of equal to
    /// the pixel height.
    /// Furthermore, we recommend that pitches and lines be multiple of 32
    /// to not break assumption that might be made by various optimizations
    /// in the video decoders, video filters and/or video converters.
    /// </remarks>
    [LibVlcFunction("libvlc_video_format_cb")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint VideoFormatCallback(out IntPtr userData, IntPtr chroma, ref uint width, ref uint height, ref uint pitches, ref uint lines);
}
