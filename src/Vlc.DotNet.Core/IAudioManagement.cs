namespace Vlc.DotNet.Core
{
    public interface IAudioManagement
    {
        IAudioOutputsManagement Outputs { get; }

        bool IsMute { get; set; }

        void ToggleMute();

        int Volume { get; set; }

        ITracksManagement Tracks { get; }

        int Channel { get; set; }

        long Delay { get; set; }
    }
}
