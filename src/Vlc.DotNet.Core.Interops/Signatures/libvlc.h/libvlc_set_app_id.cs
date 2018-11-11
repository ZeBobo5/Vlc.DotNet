using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Sets some meta-information about the application. 
    /// </summary>
    /// <seealso cref="SetUserAgent" />
    /// <param name="instance">LibVLC instance</param>
    /// <param name="id">Java-style application identifier, e.g. "com.acme.foobar"</param>
    /// <param name="version">application version numbers, e.g. "1.2.3"</param>
    /// <param name="icon">application icon name, e.g. "foobar"</param>
    [LibVlcFunction("libvlc_set_app_id")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void SetAppId(IntPtr instance, Utf8StringHandle id, Utf8StringHandle version, Utf8StringHandle icon);
}
