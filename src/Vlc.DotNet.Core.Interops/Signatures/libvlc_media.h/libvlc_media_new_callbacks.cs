using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    /// <summary>
    /// Callback prototype to open a custom bitstream input media.
    /// Note: The same media item can be opened multiple times. Each time, this callback is invoked.
    /// It should allocate and initialize any instance-specific resources, then store them in <paramref name="pData"/>.
    /// The instance resources can be freed in the <see cref="CallbackCloseMediaDelegate"/> callback.
    /// </summary>
    /// <param name="opaque">private pointer as passed to <see cref="CallbackOpenMediaDelegate"/></param>
    /// <param name="pData">storage space for a private data pointer [OUT]</param>
    /// <param name="szData">byte length of the bitstream or UINT64_MAX if unknown [OUT]</param>
    /// <returns>0 on success, non-zero on error. In case of failure, the other callbacks will not be invoked and any value stored in <paramref name="pData"/> and <paramref name="szData"/> is discarded.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int CallbackOpenMediaDelegate(IntPtr opaque, ref IntPtr pData, out ulong szData);

    /// <summary>
    /// Callback prototype to read data from a custom bitstream input media.
    /// Note: If no data is immediately available, then the callback should sleep.
    /// Warning: The application is responsible for avoiding deadlock situations. In particular, the callback should return an error if playback is stopped; if it does not return, then libvlc_media_player_stop() will never return.
    /// </summary>
    /// <param name="opaque">private pointer as set by the <see cref="CallbackOpenMediaDelegate"/> callback</param>
    /// <param name="buf">start address of the buffer to read data into</param>
    /// <param name="len">bytes length of the buffer</param>
    /// <returns>strictly positive number of bytes read, 0 on end-of-stream, or -1 on non-recoverable error</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int CallbackReadMediaDelegate(IntPtr opaque, IntPtr buf, uint len);

    /// <summary>
    /// Callback prototype to seek a custom bitstream input media.
    /// </summary>
    /// <param name="opaque">private pointer as set by the <see cref="CallbackOpenMediaDelegate"/> callback</param>
    /// <param name="offset">absolute byte offset to seek to</param>
    /// <returns>0 on success, -1 on error</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int CallbackSeekMediaDelegate(IntPtr opaque, ulong offset);

    /// <summary>
    /// Callback prototype to close a custom bitstream input media.
    /// </summary>
    /// <param name="opaque">private pointer as set by the <see cref="CallbackOpenMediaDelegate"/> callback</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void CallbackCloseMediaDelegate(IntPtr opaque);

    /// <summary>
    /// Create a media with custom callbacks to read the data from.
    /// Note: If open_cb is <see cref="IntPtr.Zero"/>, the opaque pointer will be passed to <paramref name="read_cb"/>, <paramref name="seek_cb"/> and <paramref name="close_cb"/>, and the stream size will be treated as unknown.
    /// The callbacks may be called asynchronously (from another thread). A single stream instance need not be reentrant. However the <pararef name="open_cb needs"/> to be reentrant if the media is used by multiple player instances.
    /// Warning: The callbacks may be used until all or any player instances that were supplied the media item are stopped.
    /// </summary>
    /// <returns>Return the newly created media or <see cref="IntPtr.Zero"/> on error.</returns>
    [LibVlcFunction("libvlc_media_new_callbacks")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr CreateNewMediaFromCallbacks(IntPtr mediaPlayerInstance,
        CallbackOpenMediaDelegate open_cb,
        CallbackReadMediaDelegate read_cb,
        CallbackSeekMediaDelegate seek_cb,
        CallbackCloseMediaDelegate close_cb,
        IntPtr opaque);
}
