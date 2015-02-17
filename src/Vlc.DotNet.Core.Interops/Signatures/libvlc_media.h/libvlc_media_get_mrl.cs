using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get the media resource locator (mrl) from a media descriptor object.
    /// </summary>
    [LibVlcFunction("libvlc_media_get_mrl")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr GetMediaMrl(IntPtr mediaInstance);
}
