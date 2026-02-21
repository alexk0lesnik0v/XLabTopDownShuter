using Entities.Enemies;
using Infrastructure.States;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private SpawnerEnemy m_enemySpawner;
        private void Awake()
        {
            var stateMachine =  new StateMachine();
            
            
        }
    }
}