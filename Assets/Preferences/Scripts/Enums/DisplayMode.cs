using System.ComponentModel;

namespace Preferences.Scripts.Enums
{
    public enum DisplayMode
    {
        [Description("Fullscreen")] Fullscreen = 0,
        [Description("Windowed Fullscreen")] WindowedFullscreen = 1,
        [Description("Windowed")] Windowed = 2
    }
}