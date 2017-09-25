using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public VlcMediaInstance CreateNewMediaFromFileDescriptor(int fileDescriptor)
        {
            EnsureVlcInstance();

            return VlcMediaInstance.New(this, GetInteropDelegate<CreateNewMediaFromFileDescriptor>().Invoke(myVlcInstance, fileDescriptor));
        }
    }
}
