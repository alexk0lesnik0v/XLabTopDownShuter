using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Players
{
    
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform m_target;
        [SerializeField] private NavMeshMouseResolver m_navMeshMouseResolver;
        [SerializeField] private PlayerMovement m_playerMovement;

        private Camera m_camera;

        private void Awake()
        {
            m_camera = Camera.main;
        }

        private void OnValidate()
        {
            if (!m_playerMovement)
            {
                m_playerMovement = GetComponent<PlayerMovement>();
            }

            if (!m_navMeshMouseResolver)
            {
                m_navMeshMouseResolver = GetComponent<NavMeshMouseResolver>();
            }
        }
        
        private void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector3 mousePosition = Mouse.current.position.ReadValue();
                Vector3? navPount = m_navMeshMouseResolver.GetNavMeshPoint(mousePosition);
                
                if (navPount.HasValue)
                    m_playerMovement.SetDestination(navPount.Value);
            }
        }
    }
}
