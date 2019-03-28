namespace Vlc.DotNet.Core
{
    public interface IVideoManagement
    {
        string AspectRatio { get; set; }
        string CropGeometry { get; set; }
        int Teletext { get; set; }
        ITracksManagement Tracks { get; }
        string Deinterlace { set; }
        IMarqueeManagement Marquee { get; }
        ILogoManagement Logo { get; }
        IAdjustmentsManagement Adjustments { get; }
        bool IsMouseInputEnabled { set; }
        bool IsKeyInputEnabled { set; }

        /// <summary>
        /// Gets or set the fullscreen mode for the player.
        /// <c>true</c> if the player is playing fullscreen
        /// </summary>
        bool FullScreen { get;  set; }
    }
}