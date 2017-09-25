using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetAudioOutputDevice(VlcMediaPlayerInstance mediaPlayerInstance, string audioOutputDescriptionName, string deviceName)
        {
            using (var audioOutputInterop = Utf8InteropStringConverter.ToUtf8Interop(audioOutputDescriptionName))
            using (var deviceNameInterop = Utf8InteropStringConverter.ToUtf8Interop(audioOutputDescriptionName))
            {
                GetInteropDelegate<SetAudioOutputDevice>().Invoke(mediaPlayerInstance, audioOutputInterop.DangerousGetHandle(), deviceNameInterop.DangerousGetHandle());
            }
        }
    }
}
