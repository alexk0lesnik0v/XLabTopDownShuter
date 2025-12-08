using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Markers
{
    public sealed class TargetMarker : MonoBehaviour
    {
        [Header("View")] 
        [SerializeField] private Sprite m_sprite;
        [SerializeField] private Color m_color = Color.white;

        [Space] 
        [SerializeField] [Min(0)] private float m_size = 1f;
        [SerializeField] private float m_yOffset = 0.02f;
        
        [Header("Behaviour")]
        [SerializeField] [Min(0)] private float m_lifetime = 1.25f;

        [Space] 
        [SerializeField] private bool m_isPuls = true;
        
        [Tooltip("Pulsation amplitude")]
        [SerializeField] [Range(0, 1f)] private float m_pulseOffset = 0.15f;
        [SerializeField] [Min(0.01f)]  private float m_pulseSpeed = 6f;

        private float m_initialSize;
        private SpriteRenderer m_spriteRenderer;
        private Coroutine m_showingCoroutine;

        public void Show(Vector3 worldPosition)
        {
            SetupView();
            
            gameObject.SetActive(true);
            m_spriteRenderer.enabled = true;
            transform.position = new  Vector3(worldPosition.x, worldPosition.y  + m_yOffset, worldPosition.z);
            
            if (m_showingCoroutine is not null)
                StopCoroutine(m_showingCoroutine);

            m_showingCoroutine = StartCoroutine(Showing());
        }
        
        private void SetupView()
        {
            if (!m_spriteRenderer)
            {
                var spriteObject = new GameObject(name: "Marker Sprite");
                
                spriteObject.transform.SetParent(transform, false);
                spriteObject.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                
                m_spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
                m_spriteRenderer.sortingOrder = 1000;
                m_spriteRenderer.enabled = false;
                
                m_spriteRenderer.sprite = m_sprite;
                m_spriteRenderer.color = m_color;

                m_initialSize = Mathf.Max(0.01f, m_size);
                transform.localScale = Vector3.one * m_initialSize;
            }
        }
        
        private IEnumerator Showing()
        {
            var time = 0f;

            while (time < m_lifetime)
            {
                time += Time.deltaTime;

                if (m_isPuls)
                {
                    var coefficient = 1f + Mathf.Sin(Time.time * m_pulseSpeed) *  m_pulseOffset;
                    var scale = m_initialSize * coefficient;
                    transform.localScale = Vector3.one * scale;
                }

                yield return null;
            }
            
            m_spriteRenderer.enabled = false;
            transform.localScale = Vector3.one * m_initialSize;
        }
    }
}