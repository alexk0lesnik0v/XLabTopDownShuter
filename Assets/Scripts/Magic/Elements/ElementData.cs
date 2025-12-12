using System;
using UnityEngine;

namespace Magic.Elements
{
    public sealed class ElementData : ScriptableObject
    {
        [Serializable]
        public sealed class Item
        {
            [SerializeField] private Item[] m_items;
            
            [SerializeField] private string m_elementName;
            [SerializeField] private ElementType m_type;
            [SerializeField] private Sprite m_icon;
            
            public Sprite Icon => m_icon;
            
            public ElementType type => m_type;
            
            public string ElementName => m_elementName;
        }
    }
}