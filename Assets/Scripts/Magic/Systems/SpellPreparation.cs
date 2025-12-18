using System;
using System.Collections.Generic;
using Magic.Data;
using Magic.Elements;
using Magic.Spells.Data;

namespace Magic.Systems
{
    public class SpellPreparation
    {
        public event Action OverflowOccured;
        public event Action<IReadOnlyList<ElementType>> ElementsChanged;
        
        private MagicConfig m_magicConfig;
        private List<ElementType> m_elements = new();

        public SpellPreparation(MagicConfig magicConfig)
        {
            m_magicConfig = magicConfig;
        }

        public static object ElementChanged { get; set; }

        public void AddElement(ElementType elementType)
        {
            if (m_elements.Count >= m_magicConfig.MaxElements)
            {
                Clear();
                OverflowOccured?.Invoke();
            }
            else
            {
                m_elements.Add(elementType);
                ElementsChanged?.Invoke(m_elements);
            }
        }

        public bool TryGetSpell(out BaseSpellData spell)
        {
            spell = null;

            if (m_elements.Count is 0)
            {
                return false;
            }

            foreach (var spellData in m_magicConfig.SpellsDataBase.Spells)
            {
                if (IsMatchingCombination(spellData.combination))
                {
                    spell = spellData;
                    return true;
                }
            }
            
            return false;
        }

        private bool IsMatchingCombination(IReadOnlyList<ElementType> combination)
        {
            if (combination.Count != m_elements.Count)
            {
                return false;
            }

            for (var i = 0; i < combination.Count; i++)
            {
                if (combination[i] != m_elements[i])
                {
                    return false;
                }
            }
            
            return true;
        }

        private void Clear()
        {
            m_elements.Clear();
            ElementsChanged?.Invoke(m_elements);
        }
    }
}