using System.ComponentModel;

namespace Preferences.Scripts.Enums
{
    public enum FrameRateLimit
    {
        [Description("Unlimited")] Unlimited = 0,
        [Description("30 FPS")] L30 = 30,
        [Description("60 FPS")] L60 = 60,
        [Description("120 FPS")] L120 = 120,
        [Description("144 FPS")] L144 = 144,
        [Description("160 FPS")] L160 = 160,
        [Description("165 FPS")] L165 = 165,
        [Description("180 FPS")] L180 = 180,
        [Description("200 FPS")] L200 = 200,
        [Description("240 FPS")] L240 = 240,
        [Description("360 FPS")] L360 = 360
    }
}