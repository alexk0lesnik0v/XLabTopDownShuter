using Inputs;
using Players;
using UnityEngine;

namespace Infrastructure
{
    public interface IPlayerFactorySettings
    {
        public Vector3 position { get; set; }
    }
    
    public interface IPlayerFactory
    {
        public PlayerController Create();
        
        public void Release();
    }
    
    public class PlayerFactory : IPlayerFactory, IPlayerFactorySettings
    {
        private readonly string m_path;
        private PlayerController m_playerPrefab;
        private PlayerController m_playerInstance;
        
        public Vector3 position { get; set; }
        
        public PlayerFactory(string mPath)
        {
            m_path = mPath;
        }

        public PlayerController Create()
        {
            if (m_playerPrefab is not null)
            {
                return m_playerInstance;
            }
            
            if (m_playerPrefab is null)
            {
                var playerPrefab = Resources.Load<GameObject>(m_path);
                m_playerPrefab =  playerPrefab.GetComponent<PlayerController>();
            }
            
            m_playerInstance = Object.Instantiate(m_playerPrefab, ((IPlayerFactorySettings)this).position, Quaternion.identity);
            return m_playerInstance;
        }

        public void Release()
        {
            Object.Destroy(m_playerInstance.gameObject);
            m_playerInstance = null;
        }
    }

    public class BootstrapState : MonoBehaviour, IState
    {
        [SerializeField] private MouseResolver m_mouseResolver;
        public void Enter()
        {
            
        }
    }
}