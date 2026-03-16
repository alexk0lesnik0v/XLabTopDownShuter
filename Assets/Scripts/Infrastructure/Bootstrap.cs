using UnityEngine;

namespace Infrastructure
{
    [DefaultExecutionOrder(-500)]
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Loading m_loading;

        //[SerializeField] private AudioService m_audioService;

        private void Awake()
        {
            ServiceLocator.Clear();

            //m_audioService.Initialize();
            ServiceLocator.Register(m_loading);
            //ServiceLocator.Register(m_audioService);
        }

        private void Start()
        {
            //m_audioService.Initialize();
        }
    }
}