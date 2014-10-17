using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcTheLuggageManager
    {
        public void ClearLastErrorMessage()
        {
            GetInteropDelegate<ClearLastErrorMessage>().Invoke();
        }
    }
}
