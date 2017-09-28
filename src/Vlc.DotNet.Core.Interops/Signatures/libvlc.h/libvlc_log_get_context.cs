namespace Vlc.DotNet.Core.Interops.Signatures
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Gets log message debug infos.
    ///
    /// This function retrieves self-debug information about a log message:
    /// - the name of the VLC module emitting the message,
    /// - the name of the source code module (i.e.file) and
    /// - the line number within the source code module.
    ///
    /// The returned module name and file name will be NULL if unknown.
    /// The returned line number will similarly be zero if unknown.
    /// </summary>
    /// <param name="logContext">The log message context (as passed to the <see cref="LogCallback"/>)</param>
    /// <param name="module">The module name storage.</param>
    /// <param name="file">The source code file name storage.</param>
    /// <param name="line">The source code file line number storage.</param>
    [LibVlcFunction("libvlc_log_get_context")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void GetLogContext(IntPtr logContext, out IntPtr module, out IntPtr file, out UIntPtr line);
}
