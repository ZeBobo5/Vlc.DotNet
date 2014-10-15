using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures.Rincewind
{
    /// <summary>
    /// Parse a media meta data and tracks information async. 
    /// </summary>
    [LibVlcFunction("libvlc_media_parse_async")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void ParseMediaAsync(IntPtr mediaInstance);
}
