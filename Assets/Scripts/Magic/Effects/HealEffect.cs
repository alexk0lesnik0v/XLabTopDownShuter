using Entities;
using UnityEngine;

namespace Magic.Effects
{
    public class HealEffect : IEffect
    {
        [SerializeField] [Min(0)] private float m_heal;

        public void Apply(IEffectable effectable)
        {
            if (effectable is IHealth health)
            {
                health.Heal(m_heal);
            }
        }
    }
}