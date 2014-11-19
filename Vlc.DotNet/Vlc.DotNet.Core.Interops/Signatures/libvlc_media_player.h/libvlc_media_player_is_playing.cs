using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Check if media player is playing.
    /// </summary>
    /// <returns>Return 1 if the media player is playing, 0 otherwise.</returns>
    [LibVlcFunction("libvlc_media_player_is_playing")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int IsPlaying(IntPtr mediaPlayerInstance);
}
