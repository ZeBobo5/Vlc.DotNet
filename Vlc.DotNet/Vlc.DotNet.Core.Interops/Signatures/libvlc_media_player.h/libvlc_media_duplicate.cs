using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Duplicate a media descriptor object.
    /// </summary>
    /// <returns>Return a media descriptor object.</returns>
    [LibVlcFunction("libvlc_media_duplicate")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr CloneMedia(IntPtr mediaInstance);
}
