using System.Runtime.InteropServices;
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public VlcMediaInstance CreateNewMediaFromLocation(string mrl)
        {
            using (var handle = Utf8InteropStringConverter.ToUtf8Interop(mrl))
            {
                return VlcMediaInstance.New(this, GetInteropDelegate<CreateNewMediaFromLocation>().Invoke(myVlcInstance, handle.DangerousGetHandle()));
            }
        }
    }
}
