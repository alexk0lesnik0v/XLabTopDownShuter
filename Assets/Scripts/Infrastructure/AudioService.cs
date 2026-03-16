using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Infrastructure
{
    [Serializable]
    public class AudioService
    {
        private const string MusicVolumeKey = "MusicVolume";
        private const string SoundsVolumeKey = "SoundsVolume";

        [SerializeField] private AudioMixer m_audioMixer;

        public float MusicVolume => PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
        public float SoundsVolume => PlayerPrefs.GetFloat(SoundsVolumeKey, 1f);

        public void Initialize()
        {
            ApplyMusicVolume(MusicVolume);
            ApplySoundsVolume(SoundsVolume);
        }

        public void SetMusicVolume(float value)
        {
            ApplyMusicVolume(value);
            PlayerPrefs.SetFloat(MusicVolumeKey, value);
            PlayerPrefs.Save();
        }

        public void SetSoundsVolume(float value)
        {
            ApplySoundsVolume(value);
            PlayerPrefs.SetFloat(SoundsVolumeKey, value);
            PlayerPrefs.Save();
        }

        private void ApplyMusicVolume(float value) =>
            m_audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f);

        private void ApplySoundsVolume(float value) =>
            m_audioMixer.SetFloat("SoundsVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f);
    }
}