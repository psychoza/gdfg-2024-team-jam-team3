using System;
using Preferences.Scripts.Enums;

namespace Preferences.Scripts
{
    [Serializable]
    public class PreferencesModel
    {
        public DisplayMode displayMode;
        public Resolution resolution;
        public Vsync vsync;
        public FrameRateLimit frameRateLimit;
        public MasterVolume masterVolume;
        public SfxVolume sfxVolume;
        public MusicVolume musicVolume;
        public DialogueVolume dialogueVolume;
    }
}
