using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseMenuView : MonoBehaviour
    {
        public event Action ContinueClicked;
        public event Action MainMenuClicked;
        
        [SerializeField] private Button m_continue;
        [SerializeField] private Button m_mainMenu;

        private void OnEnable()
        {
            m_continue.onClick.AddListener(OnContinueClick);
            m_continue.onClick.AddListener(OnMainMenuClick);
        }
        
        private void OnDisable()
        {
            m_continue.onClick.RemoveListener(OnContinueClick);
            m_continue.onClick.RemoveListener(OnMainMenuClick);
        }

        private void OnMainMenuClick() => 
            MainMenuClicked?.Invoke();

        private void OnContinueClick() => 
            ContinueClicked?.Invoke();
    }
}