namespace Vlc.DotNet.Core
{
    public interface IAudioManagement
    {
        IAudioOutputsManagement Outputs { get; }
    }
}
