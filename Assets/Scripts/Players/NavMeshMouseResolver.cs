using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    public class NavMeshMouseResolver : MonoBehaviour
    {
        [SerializeField] private PlayerMovement m_playerMovement;
        
        private Camera m_camera;
        
        public Vector3 GetNavMeshPoint(Vector3 mousePosition)
        {
            var ray = m_camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, 1000, ~0))
            {
                if (UnityEngine.AI.NavMesh.SamplePosition(hit.point, out var navHit, 1000, UnityEngine.AI.NavMesh.AllAreas))
                {
                    m_playerMovement.SetDestination(navHit.position);
                }
            }
            
            return m_playerMovement.transform.position;
        }
    }
}