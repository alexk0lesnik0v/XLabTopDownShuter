using System;
using Entities;
using UnityEngine;

namespace Magic.Buffs.Base.Impls
{
    [Serializable]
    public sealed class PoisonDebuff : TimedBuff
    {
        [SerializeField] [Min(0)] private float m_interval = 1;
        [SerializeField] [Min(0)] private float m_damagedPerSeconds = 2f;

        [NonSerialized] private float m_timer;
        private IHealth m_health;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            m_health = conteiner.GetComponent<IHealth>();
        }

        protected override void OnDeinitializing()
        {
            m_timer = 0;
            m_health = null;
            base.OnDeinitializing();
        }

        protected override void OnUpdated(float deltaTime)
        {
            if (m_health is not null)
            {
                Deinitialize();
                return;
            }
            
            if (m_timer < m_interval)
            {
                m_timer += deltaTime;
            }
            else
            {
                m_timer = 0;
                m_health.TakeDamage(m_damagedPerSeconds);
                // TODO Attack
            }
        }
    }
}