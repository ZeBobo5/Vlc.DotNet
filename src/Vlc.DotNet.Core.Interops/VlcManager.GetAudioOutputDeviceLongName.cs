using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public string GetAudioOutputDeviceLongName(string audioOutputDescriptionName, int deviceIndex)
        {
            EnsureVlcInstance();

            using (var audioOutputDescriptionNameInterop = Utf8InteropStringConverter.ToUtf8Interop(audioOutputDescriptionName))
            {
                return Utf8InteropStringConverter.Utf8InteropToString(GetInteropDelegate<GetAudioOutputDeviceLongName>()
                    .Invoke(myVlcInstance, audioOutputDescriptionNameInterop.DangerousGetHandle(), deviceIndex));
            }
        }
    }
}
