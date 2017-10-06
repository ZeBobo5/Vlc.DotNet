using System.Runtime.InteropServices;
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public VlcMediaInstance CreateNewMediaFromPath(string mrl)
        {
            EnsureVlcInstance();

            using (var handle = Utf8InteropStringConverter.ToUtf8Interop(mrl))
            {
                return VlcMediaInstance.New(this, GetInteropDelegate<CreateNewMediaFromPath>().Invoke(myVlcInstance, handle.DangerousGetHandle()));
            }
        }
    }
}
