using System;
#if !(NET20 || NET35)
using System.Collections.Concurrent;
#endif
using System.Collections.Generic;
using System.IO;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        private static class StreamData
        {
            public static readonly CallbackOpenMediaDelegate CallbackOpenMediaDelegate = CallbackOpenMedia;
            public static readonly CallbackReadMediaDelegate CallbackReadMediaDelegate = CallbackReadMedia;
            public static readonly CallbackSeekMediaDelegate CallbackSeekMediaDelegate = CallbackSeekMedia;
            public static readonly CallbackCloseMediaDelegate CallbackCloseMediaDelegate = CallbackCloseMedia;

            private static int CallbackOpenMedia(IntPtr opaque, out IntPtr pData, out ulong szData)
            {
                pData = opaque;
                try
                {
                    Stream stream = GetStream(opaque);
                    szData = (ulong)stream.Length;
                    stream.Seek(0L, SeekOrigin.Begin);
                    return 0;
                }
                catch (Exception)
                {
                    szData = 0UL;
                    return -1;
                }
            }

            private static IntPtr CallbackReadMedia(IntPtr opaque, IntPtr ipbuf, UIntPtr len)
            {
                try
                {
                    byte[] buf = new byte[(uint)len];
                    Stream stream = GetStream(opaque);
                    int read = stream.Read(buf, 0, (int)len);
                    System.Runtime.InteropServices.Marshal.Copy(buf, 0, ipbuf, read);
                    return new IntPtr(read);
                }
                catch (Exception)
                {
                    return new IntPtr(-1);
                }
            }

            private static Int32 CallbackSeekMedia(IntPtr opaque, UInt64 offset)
            {
                try
                {
                    Stream stream = GetStream(opaque);
                    stream.Seek((long)offset, SeekOrigin.Begin);
                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            private static void CallbackCloseMedia(IntPtr opaque)
            {
                try
                {
                    RemoveStream(opaque);
                }
                catch (Exception)
                {
                }
            }

#if NET20 || NET35
            private static readonly Dictionary<IntPtr, Stream> dicStreams = new Dictionary<IntPtr, Stream>();
#else
            private static readonly ConcurrentDictionary<IntPtr, Stream> dicStreams = new ConcurrentDictionary<IntPtr, Stream>();
#endif

            public static IntPtr AddStream(Stream stream)
            {
                IntPtr n = new IntPtr(1);
                lock (dicStreams)
                {
                    for (; ;
#if NET20 || NET35
                        n = new IntPtr(n.ToInt64() + 1L)
#else
                        n = IntPtr.Add(n, 1)
#endif
                        )
                    {
                        if (n == IntPtr.Zero)
                            return IntPtr.Zero;
                        if (!dicStreams.ContainsKey(n))
                            break;
                    }
                    dicStreams[n] = stream;
                }
                return n;
            }

            public static Stream GetStream(IntPtr n)
            {
#if NET20 || NET35
                lock (dicStreams)
                {
                    if (!dicStreams.ContainsKey(n))
                        return null;
                    return dicStreams[n];
                }
#else
                Stream result;
                if (!dicStreams.TryGetValue(n, out result))
                    return null;
                return result;
#endif
            }

            public static void RemoveStream(IntPtr n)
            {
#if NET20 || NET35
                lock (dicStreams)
                {
                    if (dicStreams.ContainsKey(n))
                        dicStreams.Remove(n);
                }
#else
                Stream result;
                dicStreams.TryRemove(n, out result);
#endif
            }
        }

        public VlcMediaInstance CreateNewMediaFromStream(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            IntPtr opaque = StreamData.AddStream(stream);

            if (opaque == IntPtr.Zero)
                return null;

            var result = VlcMediaInstance.New(this, GetInteropDelegate<CreateNewMediaFromCallbacks>().Invoke(
                myVlcInstance,
                StreamData.CallbackOpenMediaDelegate,
                StreamData.CallbackReadMediaDelegate,
                StreamData.CallbackSeekMediaDelegate,
                StreamData.CallbackCloseMediaDelegate,
                opaque
                ));

            return result;
        }
    }
}
