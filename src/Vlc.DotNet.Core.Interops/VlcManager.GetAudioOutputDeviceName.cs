using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public string GetAudioOutputDeviceName(string audioOutputDescriptionName, int deviceIndex)
        {
            using (var audioOutputInterop = Utf8InteropStringConverter.ToUtf8Interop(audioOutputDescriptionName))
            {
                return Utf8InteropStringConverter.Utf8InteropToString(GetInteropDelegate<GetAudioOutputDeviceName>().Invoke(myVlcInstance, audioOutputInterop.DangerousGetHandle(), deviceIndex));
            }
        }
    }
}
