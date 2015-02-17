using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void ReleaseAudioOutputDescription(AudioOutputDescriptionStructure description)
        {
            GetInteropDelegate<ReleaseAudioOutputDescription>().Invoke(description);
        }
    }
}
