using System.Collections.Generic;
using Magic.Buffs;
using UnityEngine;

namespace Magic.Views
{
    public sealed class BuffElementsContainerView : MonoBehaviour
    {
        [SerializeField] private BuffElementView m_buffView;
        [SerializeField] private BuffElementView m_debuffView;
        [SerializeField] private BuffConteiner m_buffConteiner;
        
        private Dictionary<string, BuffElementView> m_elements = new();

        private void OnEnable()
        {
            foreach (var buff in m_buffConteiner.Buffs)
            {
                AddElement(buff);
            }
            
            m_buffConteiner.BuffAdded += AddElement;
            m_buffConteiner.BuffRemoved += RemoveElement;
        }
        
        private void OnDisable()
        {
            foreach (var buff in m_buffConteiner.Buffs)
            {
                RemoveElement(buff);
            }
            
            m_buffConteiner.BuffAdded -= AddElement;
            m_buffConteiner.BuffRemoved -= RemoveElement;
        }
       
        private void AddElement(IBuff buff)
        {
            var element = buff.type is BuffType.Buff
                ? Instantiate(m_buffView, transform)
                : Instantiate(m_debuffView, transform);
            
            element.Initialize(buff);
            m_elements.Add(buff.id, element);
        }
        
        private void RemoveElement(IBuff buff)
        {
            var element = m_elements[buff.id];
            element.Deinitialize();
            
            Destroy(element);
            m_elements.Remove(buff.id);
        }
    }
}