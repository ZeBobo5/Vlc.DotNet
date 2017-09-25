using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Create a media for an already open file descriptor.
    /// The file descriptor shall be open for reading (or reading and writing).
    /// 
    /// Regular file descriptors, pipe read descriptors and character device
    /// descriptors (including TTYs) are supported on all platforms.
    /// Block device descriptors are supported where available.
    /// Directory descriptors are supported on systems that provide <c>fdopendir()</c>.
    /// Sockets are supported on all platforms where they are file descriptors,
    /// i.e. all except Windows.
    /// </summary>
    /// <remarks>
    /// This library will <b>not</b> automatically close the file descriptor
    /// under any circumstance. Nevertheless, a file descriptor can usually only be
    /// rendered once in a media player. To render it a second time, the file
    /// descriptor should probably be rewound to the beginning with lseek().
    /// </remarks>
    /// <param name="instance">
    /// The instance
    /// </param>
    /// <param name="fd">
    /// An open file descriptor
    /// </param>
    /// <returns>
    /// the newly created media or NULL on error
    /// </returns>
    [LibVlcFunction("libvlc_media_new_fd")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr CreateNewMediaFromFileDescriptor(IntPtr instance, int fd);
}
