using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public VlcMediaInstance CreateNewMediaFromLocation(string mrl)
        {
            using (var handle = Utf8InteropStringConverter.ToUtf8StringHandle(mrl))
            {
                return VlcMediaInstance.New(this, myLibraryLoader.GetInteropDelegate<CreateNewMediaFromLocation>().Invoke(myVlcInstance, handle));
            }
        }
    }
}
