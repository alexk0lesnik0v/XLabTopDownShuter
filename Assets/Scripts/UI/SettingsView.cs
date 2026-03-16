using System;
using Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsView : MonoBehaviour
    {
        public event Action Closed;

        [SerializeField] private Slider m_musicSlider;
        [SerializeField] private Slider m_soundsSlider;
        [SerializeField] private Button m_acceptButton;
        [SerializeField] private TMP_Text m_musicValueText;
        [SerializeField] private TMP_Text m_soundsValueText;

        private AudioService m_audioService;

        private void Start()
        {
            m_audioService = ServiceLocator.Resolve<AudioService>();
            InitializeSliders();
        }

        private void OnEnable()
        {
            InitializeSliders();
            m_musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
            m_soundsSlider.onValueChanged.AddListener(OnSoundsVolumeChanged);
            m_acceptButton.onClick.AddListener(OnAcceptClick);
        }

        private void OnDisable()
        {
            m_musicSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
            m_soundsSlider.onValueChanged.RemoveListener(OnSoundsVolumeChanged);
            m_acceptButton.onClick.RemoveListener(OnAcceptClick);
        }

        private void InitializeSliders()
        {
            if(m_audioService == null)
            {
                return;
            }

            m_musicSlider.SetValueWithoutNotify(m_audioService.MusicVolume);
            m_soundsSlider.SetValueWithoutNotify(m_audioService.SoundsVolume);

            SetValueText(m_musicValueText, m_audioService.MusicVolume);
            SetValueText(m_soundsValueText, m_audioService.SoundsVolume);
        }

        private void OnMusicVolumeChanged(float value)
        {
            m_audioService?.SetMusicVolume(value);
            SetValueText(m_musicValueText, value);
        }

        private void OnSoundsVolumeChanged(float value)
        {
            m_audioService?.SetSoundsVolume(value);
            SetValueText(m_soundsValueText, value);
        }

        private void OnAcceptClick()
        {
            Closed?.Invoke();
            gameObject.SetActive(false);
        }

        private static void SetValueText(TMP_Text label, float value) => label.text = Mathf.RoundToInt(value * 100f).ToString();
    }
}