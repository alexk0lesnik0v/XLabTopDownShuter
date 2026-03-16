using Cameras;
using Entities.Enemies;
using Infrastructure.States;
using Markers;
using Players;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Loading m_loading;
        
        private void Awake()
        {
            ServiceLocator.Clear();
            ServiceLocator.Register(m_loading);
        }
    }
}