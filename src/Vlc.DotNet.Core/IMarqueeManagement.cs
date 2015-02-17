namespace Vlc.DotNet.Core
{
    public interface IMarqueeManagement
    {
        bool Enabled { get; set; }
        int Color { get; set; }
        string Text { get; set; }
        int Opacity { get; set; }
        int Position { get; set; }
        int Refresh { get; set; }
        int Size { get; set; }
        int Timeout { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}
