using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Add an option to the media with configurable flags.
    /// </summary>
    [LibVlcFunction("libvlc_media_add_option_flag")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void AddOptionFlagToMedia(IntPtr mediaInstance, IntPtr mrl, uint flag);
}
