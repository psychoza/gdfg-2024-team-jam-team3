using System.ComponentModel;

namespace Preferences.Scripts.Enums
{
    public enum Resolution
    {
        [Description("1024 x 576")] R1024X576 = 0,
        [Description("1280 x 720")] R1280X720 = 1,
        [Description("1366 x 768")] R1366X768 = 2,
        [Description("1600 x 900")] R1600X900 = 3,
        [Description("1920 x 1080")] R1920X1080 = 4,
        [Description("2560 x 1440")] R2560X1440 = 5,
        [Description("3840 x 2160")] R3840X2160 = 6
    }
}