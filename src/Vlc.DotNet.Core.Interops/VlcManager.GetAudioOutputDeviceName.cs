using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        [Obsolete("Use GetAudioOutputDeviceList instead")]
        public string GetAudioOutputDeviceName(string audioOutputDescriptionName, int deviceIndex)
        {
            using (var audioOutputInterop = Utf8InteropStringConverter.ToUtf8StringHandle(audioOutputDescriptionName))
            {
                return Utf8InteropStringConverter.Utf8InteropToString(myLibraryLoader.GetInteropDelegate<GetAudioOutputDeviceName>().Invoke(myVlcInstance, audioOutputInterop, deviceIndex));
            }
        }
    }
}
