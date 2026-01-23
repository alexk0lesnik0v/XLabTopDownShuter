using System.Collections.Generic;
using Magic.Buffs;
using UnityEngine;

namespace Entities.Views
{
    public sealed class BuffElementContainerView : MonoBehaviour
    {
        [SerializeField] private BuffElementView m_buffView;
        [SerializeField] private BuffElementView m_debuffView;
        [SerializeField] private BuffConteiner m_buffConteiner;
        
        private Dictionary<IBuff, BuffElementView> m_elements = new();

        private void OnEnable()
        {
            foreach (var buff in m_buffConteiner.Buffs)
            {
                AddElement(buff);
            }
            
            m_buffConteiner.BuffAdded += AddElement;
            m_buffConteiner.BuffRemoved += RemoveElement;
        }

        private void RemoveElement(IBuff buff)
        {
            var element = m_elements[buff];
            Destroy(element);
            
            m_elements.Remove(buff);
        }

        private void AddElement(IBuff buff)
        {
            var element = Instantiate(m_buffView, transform);
            m_elements.Add(buff, element);
        }

        private void OnDisable()
        {
            foreach (var buff in m_buffConteiner.Buffs)
            {
                RemoveElement(buff);
            }
        }
    }
}