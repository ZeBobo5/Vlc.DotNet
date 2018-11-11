using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Sets the application name.
    /// LibVLC passes this as the user agent string when a protocol requires it.
    /// </summary>
    /// <param name="instance">LibVLC instance</param>
    /// <param name="name">human-readable application name, e.g. "FooBar player 1.2.3"</param>
    /// <param name="http">HTTP User Agent, e.g. "FooBar/1.2.3 Python/2.6.0"</param>
    [LibVlcFunction("libvlc_set_user_agent")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetUserAgent(IntPtr instance, Utf8StringHandle name, Utf8StringHandle http);
}
