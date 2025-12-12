using UnityEngine;

namespace Magic.Spells.Data
{
    [CreateAssetMenu(fileName = "AoeSpellData", menuName = "XLab/Magic/Spells/Aoe Spell")]
    public class AoeSpellData : BaseSpellsData
    {
        [SerializeField] [Min(0)] private float m_radius;
        
        public float Radius => m_radius;
    }
}