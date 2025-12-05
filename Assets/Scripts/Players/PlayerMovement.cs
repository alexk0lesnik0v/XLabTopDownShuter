using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Players
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent m_agent;
        [SerializeField] private PlayerMovement m_playerMovement;

        private void OnValidate()
        {
            m_agent = GetComponent<NavMeshAgent>();
        }

        private void SetDestination(Vector3 destination)
        {
            
        }

        private void Update()
        {
            
        }
    }
}