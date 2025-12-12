using UnityEngine;

namespace Magic.Spells.Data
{
    [CreateAssetMenu(fileName = "TargetSpellData", menuName = "XLab/Magic/Spells/Target Spell")]
    public class TargetSpellData : BaseSpellsData
    {
        [SerializeField] [Min(0)] private float m_speed;
        public float Speed => m_speed;
    }
}