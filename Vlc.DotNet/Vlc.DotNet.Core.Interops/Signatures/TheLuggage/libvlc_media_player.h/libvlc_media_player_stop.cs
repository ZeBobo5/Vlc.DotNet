using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures.TheLuggage
{
    /// <summary>
    /// Stop.
    /// </summary>
    [LibVlcFunction("libvlc_media_player_stop")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void Stop(IntPtr mediaPlayerInstance);
}
