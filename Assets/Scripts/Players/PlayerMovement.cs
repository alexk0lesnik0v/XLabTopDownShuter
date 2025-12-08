using UnityEngine;
using UnityEngine.AI;

namespace Players
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent m_agent;
        [SerializeField] private PlayerMovement m_playerMovement;

        private void OnValidate()
        {
            if (!m_agent)
            {
                m_agent = GetComponent<NavMeshAgent>();
            }
        }

        public void SetDestination(Vector3 navMeshPoint)
        {
            m_agent.SetDestination(navMeshPoint);
        }

        private void Update()
        {
            
        }
    }
}