using System.Collections.Generic;
using UnityEngine;

namespace Magic.Spells.Data
{
    [CreateAssetMenu(fileName = "SpellsDataBase", menuName = "XLab/Magic/Spells/Spells DataBase")]
    public sealed class SpellDataBase : ScriptableObject
    {
        [SerializeField] private BaseSpellData[] m_spells;
        
        public IReadOnlyList<BaseSpellData> Spells => m_spells;
     }
}