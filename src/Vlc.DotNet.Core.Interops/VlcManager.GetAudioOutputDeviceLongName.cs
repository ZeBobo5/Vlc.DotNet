using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public string GetAudioOutputDeviceLongName(string audioOutputDescriptionName, int deviceIndex)
        {
            return IntPtrExtensions.ToStringAnsi(GetInteropDelegate<GetAudioOutputDeviceLongName>().Invoke(myVlcInstance, StringExtensions.ToHGlobalAnsi(audioOutputDescriptionName), deviceIndex));
        }
    }
}
