using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Check if media player can pause.
    /// </summary>
    [LibVlcFunction("libvlc_media_player_can_pause")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int IsPausable(IntPtr mediaPlayerInstance);
}
