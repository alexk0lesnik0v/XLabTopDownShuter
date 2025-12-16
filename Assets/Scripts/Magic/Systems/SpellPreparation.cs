using System;
using System.Collections.Generic;
using Magic.Data;
using Magic.Elements;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;

namespace Magic.Systems
{
    public class SpellPreparation
    {
        public Action OverflowOccured;
        public event Action<IReadOnlyList<ElementType>> ElementsChanged;
        
        private MagicConfig m_magicConfig;
        private List<ElementType> m_elements = new();

        public SpellPreparation(MagicConfig [mConfig])
        {
            throw new NotImplementedException();
        }

        public static object ElementChanged { get; set; }

        public void AddElement(ElementType elementType)
        {
            if (m_elements.Count >= m_magicConfig.MaxElements)
            {
                Clear();
                // TODO Overflow occured
            }
            else
            {
                m_elements.Add(elementType);
                // TODO InvokeChanged
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
                spell = spellData;
                return true;
            }
            
            return false;
        }

        private bool IsMatchungCombination(IReadOnlyList<ElementType> combination)
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
        }

        private void Clear()
        {
            throw new System.NotImplementedException();
        }
    }

    public class BaseSpellData
    {
        
    }
}