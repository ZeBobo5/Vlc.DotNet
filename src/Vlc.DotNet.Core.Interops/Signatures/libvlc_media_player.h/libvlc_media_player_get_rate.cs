using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Get the requested media play rate.
    /// </summary>
    [LibVlcFunction("libvlc_media_player_get_rate")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate float GetRate(IntPtr mediaPlayerInstance);
}
