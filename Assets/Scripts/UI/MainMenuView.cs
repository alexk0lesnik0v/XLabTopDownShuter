using System;
using Infrastructure;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button m_playButton;
        [SerializeField] private Button m_exitButton;
        [SerializeField] private Button m_settingsButton;
        [SerializeField] private SettingsView m_settingsView;

        private Loading m_loading;

        private void Start()
        {
            m_loading = ServiceLocator.Resolve<Loading>();
            m_settingsView.Closed += OnSettingsClosed;
        }

        private void OnEnable()
        {
            m_playButton.onClick.AddListener(OnPlayClick);
            m_exitButton.onClick.AddListener(OnExitClick);
            m_settingsButton.onClick.AddListener(OnSettingsClick);
            m_settingsView.Closed += OnSettingsClosed;
        }

        private void OnDisable()
        {
            m_playButton.onClick.RemoveListener(OnPlayClick);
            m_exitButton.onClick.RemoveListener(OnExitClick);
            m_settingsButton.onClick.RemoveListener(OnSettingsClick);
            m_settingsView.Closed -= OnSettingsClosed;
        }

        private void OnSettingsClick()
        {
            gameObject.SetActive(false);
            m_settingsView.gameObject.SetActive(true);
        }

        private void OnSettingsClosed()
        {
            gameObject.SetActive(true);
        }

        private void OnPlayClick()
        {
            gameObject.SetActive(false);
            m_loading.LoadScene(GlobalConstants.Scenes.Game);
        }

        private void OnExitClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#endif

            Application.Quit();
        }
    }
}