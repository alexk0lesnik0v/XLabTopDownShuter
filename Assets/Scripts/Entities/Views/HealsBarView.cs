using UnityEngine;
using UnityEngine.UI;

namespace Entities.Views
{
    public class HealsBarView : MonoBehaviour
    {
        [SerializeField] private Image m_bar;
        [SerializeField] private HealthComponent m_healthComponent;

        private void OnEnable()
        {
            m_healthComponent.ValueChanged += SetValue;
        }

        private void OnDisable()
        {
            m_healthComponent.ValueChanged -= SetValue;
        }

        private void SetValue()
        {
            m_bar.fillAmount = (float)m_healthComponent.value;
        }
    }
}