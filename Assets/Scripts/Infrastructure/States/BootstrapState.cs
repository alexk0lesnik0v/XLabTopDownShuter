using Inputs;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState : MonoBehaviour, IState
    {
        [SerializeField] private MouseResolver m_mouseResolver;
        
        public void Enter()
        {
            ServiceLocator.Register(m_mouseResolver);
        }

        public void Exit()
        {
         
        }
    }
}