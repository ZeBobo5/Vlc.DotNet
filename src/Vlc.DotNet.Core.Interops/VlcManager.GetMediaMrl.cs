﻿using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public string GetMediaMrl(VlcMediaInstance mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            var ptr = myLibraryLoader.GetInteropDelegate<GetMediaMrl>().Invoke(mediaInstance);
            return Utf8InteropStringConverter.Utf8InteropToString(ptr);
        }
    }
}
