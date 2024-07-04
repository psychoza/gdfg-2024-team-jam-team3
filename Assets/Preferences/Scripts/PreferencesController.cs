using System;
using System.IO;
using Preferences.Scripts.Enums;
using UnityEngine;
using Resolution = Preferences.Scripts.Enums.Resolution;

namespace Preferences.Scripts
{
    public class PreferencesController : MonoBehaviour
    {
        [SerializeField] private PreferencesModel model;

        private const string k_PreferenceFileName = "player.prefs";
        private const string k_DataFolder = "/Data/";
        private string _prefFolder;
        private string _prefFilePath;

        [SerializeField] private PreferencesView view;
        [SerializeField] private PreferenceTab currentTab = PreferenceTab.Display;

        private readonly Preference<DisplayMode> _displayMode = new(DisplayMode.Fullscreen);
        private readonly Preference<Resolution> _resolution = new(Resolution.R1600X900);
        private readonly Preference<Vsync> _vsync = new(Vsync.Off);
        private readonly Preference<FrameRateLimit> _frameRateLimit = new(FrameRateLimit.L60);
        private readonly Preference<MasterVolume> _masterVolume = new(MasterVolume.V100);
        private readonly Preference<SfxVolume> _sfxVolume = new(SfxVolume.V100);
        private readonly Preference<MusicVolume> _musicVolume = new(MusicVolume.V100);
        private readonly Preference<DialogueVolume> _dialogueVolume = new(DialogueVolume.V100);

        public static event Action<PreferenceTab> OnTabSelected;

        public void SelectTab(int tab) => OnTabSelected?.Invoke((PreferenceTab)tab);

        private void Start()
        {
            _prefFolder = $"{Application.streamingAssetsPath}/{k_DataFolder}";
            _prefFilePath = Path.Combine(_prefFolder, k_PreferenceFileName);
            LoadPreferences();
            view.InitializeView(model);
            view.WireUpButtons(this);
        }

        private void LoadPreferences()
        {
            if (!Directory.Exists(_prefFolder))
                Directory.CreateDirectory(_prefFolder);

            if (File.Exists(_prefFilePath))
            {
                TextReader reader = new StreamReader(_prefFilePath);
                model = JsonUtility.FromJson<PreferencesModel>(reader.ReadToEnd());
                reader.Close();
            }
            else
            {
                model = new PreferencesModel
                {
                    displayMode = DisplayMode.Fullscreen,
                    resolution = Resolution.R1600X900,
                    vsync = Vsync.Off,
                    frameRateLimit = FrameRateLimit.L60,
                    masterVolume = MasterVolume.V100,
                    sfxVolume = SfxVolume.V100,
                    musicVolume = MusicVolume.V100,
                    dialogueVolume = DialogueVolume.V100
                };
            }

            _displayMode.Value = model.displayMode;
            _resolution.Value = model.resolution;
            _vsync.Value = model.vsync;
            _frameRateLimit.Value = model.frameRateLimit;
            _masterVolume.Value = model.masterVolume;
            _sfxVolume.Value = model.sfxVolume;
            _musicVolume.Value = model.musicVolume;
            _dialogueVolume.Value = model.dialogueVolume;
        }

        public void SavePreferences()
        {
            if (!Directory.Exists(_prefFolder))
                Directory.CreateDirectory(_prefFolder);
            
            TextWriter writer = new StreamWriter(_prefFilePath);
            var json = JsonUtility.ToJson(model);
            writer.WriteLine(json);
            writer.Close();
        }

        public string IncrementPreference<T>() where T : Enum
        {
            if (typeof(T) == typeof(DisplayMode))
            {
                model.displayMode = _displayMode.IncrementValue();
                return model.displayMode.GetDescription();
            }

            if (typeof(T) == typeof(Resolution))
            {
                model.resolution = _resolution.IncrementValue();
                return model.resolution.GetDescription();
            }

            if (typeof(T) == typeof(Vsync))
            {
                model.vsync = _vsync.IncrementValue();
                return model.vsync.GetDescription();
            }

            if (typeof(T) == typeof(FrameRateLimit))
            {
                model.frameRateLimit = _frameRateLimit.IncrementValue();
                return model.frameRateLimit.GetDescription();
            }

            if (typeof(T) == typeof(MasterVolume))
            {
                model.masterVolume = _masterVolume.IncrementValue();
                return model.masterVolume.GetDescription();
            }

            if (typeof(T) == typeof(SfxVolume))
            {
                model.sfxVolume = _sfxVolume.IncrementValue();
                return model.sfxVolume.GetDescription();
            }

            if (typeof(T) == typeof(MusicVolume))
            {
                model.musicVolume = _musicVolume.IncrementValue();
                return model.musicVolume.GetDescription();
            }

            if (typeof(T) == typeof(DialogueVolume))
            {
                model.dialogueVolume = _dialogueVolume.IncrementValue();
                return model.dialogueVolume.GetDescription();
            }

            return null;
        }

        public string DecrementPreference<T>() where T : Enum
        {
            if (typeof(T) == typeof(DisplayMode))
            {
                model.displayMode = _displayMode.DecrementValue();
                return model.displayMode.GetDescription();
            }

            if (typeof(T) == typeof(Resolution))
            {
                model.resolution = _resolution.DecrementValue();
                return model.resolution.GetDescription();
            }

            if (typeof(T) == typeof(Vsync))
            {
                model.vsync = _vsync.DecrementValue();
                return model.vsync.GetDescription();
            }

            if (typeof(T) == typeof(FrameRateLimit))
            {
                model.frameRateLimit = _frameRateLimit.DecrementValue();
                return model.frameRateLimit.GetDescription();
            }

            if (typeof(T) == typeof(MasterVolume))
            {
                model.masterVolume = _masterVolume.DecrementValue();
                return model.masterVolume.GetDescription();
            }

            if (typeof(T) == typeof(SfxVolume))
            {
                model.sfxVolume = _sfxVolume.DecrementValue();
                return model.sfxVolume.GetDescription();
            }

            if (typeof(T) == typeof(MusicVolume))
            {
                model.musicVolume = _musicVolume.DecrementValue();
                return model.musicVolume.GetDescription();
            }

            if (typeof(T) == typeof(DialogueVolume))
            {
                model.dialogueVolume = _dialogueVolume.DecrementValue();
                return model.dialogueVolume.GetDescription();
            }

            return null;
        }
    }
}