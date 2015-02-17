using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Set media chapter (if applicable).
    /// </summary>
    [LibVlcFunction("libvlc_media_player_set_chapter")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetMediaChapter(IntPtr mediaPlayerInstance, int chapter);
}
