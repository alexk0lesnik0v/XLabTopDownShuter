using System;
using Magic.Buffs;
using UnityEngine;

namespace Magic.Effects
{
    [Serializable]
    public class BuffEffect : IEffect
    {
        [SerializeReferenceDropdown]
        [SerializeReference] private IBuff[] m_buffs;

        public void Apply(IEffectable effectable)
        {
            if (effectable is BuffConteiner conteiner)
            {
                foreach (var buff in m_buffs)
                {
                    conteiner.Add(buff.Clone() as IBuff);
                }
            }
        }
    }
}