﻿using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public int GetAudioOutputDeviceCount(string outputName)
        {
            EnsureVlcInstance();

            return GetInteropDelegate<GetAudioOutputDeviceCount>().Invoke(myVlcInstance, outputName);
        }
    }
}
