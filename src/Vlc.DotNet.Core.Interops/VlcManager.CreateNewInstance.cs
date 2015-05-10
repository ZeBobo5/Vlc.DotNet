using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public void CreateNewInstance(string[] args)
        {
            if (args == null)
                args = new string[0];
            myVlcInstance = new VlcInstance(this, GetInteropDelegate<CreateNewInstance>().Invoke(args.Length, args));
        }
    }
}
