using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void SetAudioOutput(AudioOutputDescriptionStructure output)
        {
            SetAudioOutput(output.Name);
        }

        public void SetAudioOutput(string outputName)
        {
            EnsureVlcInstance();

            using (var outputInterop = Utf8InteropStringConverter.ToUtf8Interop(outputName))
            {
                GetInteropDelegate<SetAudioOutput>().Invoke(myVlcInstance, outputInterop.DangerousGetHandle());
            }
        }
    }
}
