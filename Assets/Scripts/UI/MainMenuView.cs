using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuView : MonoBehaviour
    {
        public event Action PlayClicked;
        public event Action ExitClicked;
        
        [SerializeField] private Button m_playButton;
        [SerializeField] private Button m_exitButton;
    }
}