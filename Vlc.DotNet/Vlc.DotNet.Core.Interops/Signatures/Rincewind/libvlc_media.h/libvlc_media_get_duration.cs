using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures.Rincewind
{
    /// <summary>
    /// Get duration (in ms) of media descriptor object item.
    /// </summary>
    [LibVlcFunction("libvlc_media_get_duration")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate long GetMediaDuration(IntPtr mediaInstance);
}
