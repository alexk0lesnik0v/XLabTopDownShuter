using Entities.Enemies;
using Infrastructure.States;
using Players;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private BootstrapState m_bootstrapState;
        [SerializeField] private DeadMenuView m_deadMenuView;
        [SerializeField] private SpawnerEnemy m_enemySpawner;
        [SerializeField] private PlayerController m_playerController;
        
        private void Awake()
        {
            var stateMachine =  new StateMachine();
            m_bootstrapState.Initialize(stateMachine);
            
            stateMachine.Initialize(
                m_bootstrapState,
                new PauseMenuState(stateMachine),
                new DeadState(stateMachine, m_deadMenuView),
                new GameplayState(stateMachine, m_enemySpawner, m_playerController));
            
            stateMachine.ChangedState<BootstrapState>();
        }
    }
}