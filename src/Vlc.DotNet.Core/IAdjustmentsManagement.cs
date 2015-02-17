namespace Vlc.DotNet.Core
{
    public interface IAdjustmentsManagement
    {
        bool Enabled { get; set; }
        float Contrast { get; set; }
        float Brightness { get; set; }
        float Hue { get; set; }
        float Saturation { get; set; }
        float Gamma { get; set; }
    }
}
