using System.Collections.Generic;
using UnityEngine;

namespace Magic.Spells.Data
{
    [CreateAssetMenu(fileName = "SpellsDataBase", menuName = "XLab/Magic/Spells/Spells DataBase")]
    public sealed class SpellDataBase : ScriptableObject
    {
        [SerializeField] private BaseSpellsData[] m_spells;
        
        public IReadOnlyList<BaseSpellsData> Spells => m_spells;
     }
}