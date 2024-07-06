using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Preferences.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Resolution = Preferences.Scripts.Enums.Resolution;

namespace Preferences.Scripts
{
    public class PreferencesView : MonoBehaviour
    {
        [Header("Tab Buttons")] [SerializeField]
        private Button displayTabButton;

        [SerializeField] private Button audioTabButton;
        [SerializeField] private Button controlsTabButton;
        [SerializeField] private Button gameTabButton;
        [Header("Tab Views")] [SerializeField] private GameObject displayView;
        [SerializeField] private GameObject audioView;
        [SerializeField] private GameObject controlsView;
        [SerializeField] private GameObject gameView;
        [SerializeField] private Dictionary<PreferenceTab, (GameObject, Button)> _tabViews = new();

        [Header("Display Inputs")] [SerializeField]
        private TMP_Text displayModeText;
        [SerializeField] private Button displayModeDecrease;
        [SerializeField] private Button displayModeIncrease;
        [SerializeField] private TMP_Text resolutionText;
        [SerializeField] private Button resolutionDecrease;
        [SerializeField] private Button resolutionIncrease;
        [SerializeField] private TMP_Text vsyncText;
        [SerializeField] private Button vsyncDecrease;
        [SerializeField] private Button vsyncIncrease;
        [SerializeField] private TMP_Text frameRateLimitText;
        [SerializeField] private Button frameRateLimitDecrease;
        [SerializeField] private Button frameRateLimitIncrease;
        
        [Header("Audio Inputs")] [SerializeField]
        private TMP_Text masterVolumeText;
        [SerializeField] private Button masterVolumeDecrease;
        [SerializeField] private Button masterVolumeIncrease;
        [SerializeField] private TMP_Text sfxVolumeText;
        [SerializeField] private Button sfxVolumeDecrease;
        [SerializeField] private Button sfxVolumeIncrease;
        [SerializeField] private TMP_Text musicVolumeText;
        [SerializeField] private Button musicVolumeDecrease;
        [SerializeField] private Button musicVolumeIncrease;
        [SerializeField] private TMP_Text dialogueVolumeText;
        [SerializeField] private Button dialogueVolumeDecrease;
        [SerializeField] private Button dialogueVolumeIncrease;

        private Color normalTabColor;
        private Color disabledTabColor;

        private void Awake()
        {
            InitializeTabs();
            SetActiveTab(PreferenceTab.Display);
        }

        private void OnEnable()
        {
            PreferencesController.OnTabSelected += SetActiveTab;
        }

        private void OnDisable()
        {
            PreferencesController.OnTabSelected -= SetActiveTab;
        }

        private void InitializeTabs()
        {
            _tabViews = new Dictionary<PreferenceTab, (GameObject, Button)>
            {
                { PreferenceTab.Display, (displayView, displayTabButton) },
                { PreferenceTab.Audio, (audioView, audioTabButton) },
                { PreferenceTab.Controls, (controlsView, controlsTabButton) },
                { PreferenceTab.Game, (gameView, gameTabButton) }
            };
            normalTabColor = displayTabButton.colors.normalColor;
            disabledTabColor = displayTabButton.colors.disabledColor;
        }

        private void SetActiveTab(PreferenceTab tab)
        {
            if (_tabViews.Count == 0)
                InitializeTabs();

            var currentView = _tabViews[tab];
            var colors = currentView.Item2.colors;
            foreach (var view in _tabViews.Values)
            {
                view.Item1.SetActive(false);
                colors.normalColor = disabledTabColor;
                view.Item2.colors = colors;
            }

            currentView.Item1.SetActive(true);
            colors.normalColor = normalTabColor;
            currentView.Item2.colors = colors;
        }

        public void InitializeView(PreferencesModel model)
        {
            displayModeText.text =model.displayMode.GetDescription();
            resolutionText.text =model.resolution.GetDescription();
            vsyncText.text =model.vsync.GetDescription();
            frameRateLimitText.text =model.frameRateLimit.GetDescription();
            masterVolumeText.text =model.masterVolume.GetDescription();
            sfxVolumeText.text =model.sfxVolume.GetDescription();
            musicVolumeText.text =model.musicVolume.GetDescription();
            dialogueVolumeText.text =model.dialogueVolume.GetDescription();
        }

        public void WireUpButtons(PreferencesController controller)
        {
            displayModeDecrease.onClick.AddListener(() => displayModeText.text = controller.DecrementPreference<DisplayMode>());
            displayModeIncrease.onClick.AddListener(() => displayModeText.text = controller.IncrementPreference<DisplayMode>());
            resolutionDecrease.onClick.AddListener(() => resolutionText.text = controller.DecrementPreference<Resolution>());
            resolutionIncrease.onClick.AddListener(() => resolutionText.text = controller.IncrementPreference<Resolution>());
            vsyncDecrease.onClick.AddListener(() => vsyncText.text = controller.DecrementPreference<Vsync>());
            vsyncIncrease.onClick.AddListener(() => vsyncText.text = controller.IncrementPreference<Vsync>());
            frameRateLimitDecrease.onClick.AddListener(() => frameRateLimitText.text = controller.DecrementPreference<FrameRateLimit>());
            frameRateLimitIncrease.onClick.AddListener(() => frameRateLimitText.text = controller.IncrementPreference<FrameRateLimit>());
            masterVolumeDecrease.onClick.AddListener(() => masterVolumeText.text = controller.DecrementPreference<MasterVolume>());
            masterVolumeIncrease.onClick.AddListener(() => masterVolumeText.text = controller.IncrementPreference<MasterVolume>());
            sfxVolumeDecrease.onClick.AddListener(() => sfxVolumeText.text = controller.DecrementPreference<SfxVolume>());
            sfxVolumeIncrease.onClick.AddListener(() => sfxVolumeText.text = controller.IncrementPreference<SfxVolume>());
            musicVolumeDecrease.onClick.AddListener(() => musicVolumeText.text = controller.DecrementPreference<MusicVolume>());
            musicVolumeIncrease.onClick.AddListener(() => musicVolumeText.text = controller.IncrementPreference<MusicVolume>());
            dialogueVolumeDecrease.onClick.AddListener(() => dialogueVolumeText.text = controller.DecrementPreference<DialogueVolume>());
            dialogueVolumeIncrease.onClick.AddListener(() => dialogueVolumeText.text = controller.IncrementPreference<DialogueVolume>());
        }
    }
}