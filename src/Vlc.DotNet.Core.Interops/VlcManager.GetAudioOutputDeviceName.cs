using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public string GetAudioOutputDeviceName(string audioOutputDescriptionName, int deviceIndex)
        {
            return IntPtrExtensions.ToStringAnsi(GetInteropDelegate<GetAudioOutputDeviceName>().Invoke(myVlcInstance, StringExtensions.ToHGlobalAnsi(audioOutputDescriptionName), deviceIndex));
        }
    }
}
