using System.Collections.Generic;
using System.Linq;
using Magic.Elements;
using UnityEngine;

namespace Magic.Spells.Data
{
    public abstract class BaseSpellsData : ScriptableObject
    {
        [SerializeField] private string m_spellName;
        [SerializeField] private GameObject m_visualEffect;
        [SerializeField] private ElementType[] m_combination;

        public string SpellName => m_spellName;
        public GameObject VisualEffect => m_visualEffect;
        public IReadOnlyList<ElementType> Combination => m_combination;

        private void OnValidate()
        {
            if (m_combination?.Length > 3)
            {
                m_combination = m_combination.Take(3).ToArray();
            }
        }
    }
}