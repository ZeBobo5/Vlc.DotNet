﻿using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void ParseMediaAsync(VlcMediaInstance mediaPlayerInstance)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            myLibraryLoader.GetInteropDelegate<ParseMediaAsync>().Invoke(mediaPlayerInstance);
        }
    }
}
