using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public VlcMediaInstance CreateNewMediaFromPath(string mrl)
        {
            using (var handle = Utf8InteropStringConverter.ToUtf8StringHandle(mrl))
            {
                return VlcMediaInstance.New(this, myLibraryLoader.GetInteropDelegate<CreateNewMediaFromPath>().Invoke(myVlcInstance, handle));
            }
        }
    }
}
