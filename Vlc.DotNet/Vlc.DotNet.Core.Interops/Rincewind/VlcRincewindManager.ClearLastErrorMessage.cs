using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcRincewindManager
    {
        public void ClearLastErrorMessage()
        {
            GetInteropDelegate<ClearLastErrorMessage>().Invoke();
        }
    }
}
