using UnityEngine;

namespace Magic.Spells.Data
{
    public class NonTargetSpellData : BaseSpellsData
    {
        [SerializeField] [Min(0)] private float m_range;
        [SerializeField] [Min(0)] private float m_duration;
        [SerializeField] [Min(0)] private float m_effectInterval;
        
        public float Range => m_range;
        public float Duration => m_duration;
        public float EffectInterval => m_effectInterval;
    }
}