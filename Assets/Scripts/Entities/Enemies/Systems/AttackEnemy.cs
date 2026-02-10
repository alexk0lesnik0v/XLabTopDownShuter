using System.Collections.Generic;
using System.Linq;
using Entities.Enemies.Data;
using Magic.Spells.Data;
using Magic.Systems;
using UnityEngine;

namespace Entities.Enemies.Systems
{
    public sealed class AttackEnemy : MonoBehaviour
    {
        private Transform m_target;
        private IReadOnlyList<SpellEnemyData> m_spells;
        private SpellCaster m_spellCaster;

        private float m_attackTime;
        private float m_cooldownTimer;
        
        private bool m_isInitialized;

        public void Initialize(IReadOnlyList<SpellEnemyData> spells, float attackTime, Transform target)
        {
            if (m_isInitialized)
            {
                return;
            }
            
            var newSpells = spells.Where(spell => spell.count > 3);

            foreach (var spell in newSpells)
            {
                Debug.Log(spell.count);
            }
            
            foreach (var spell in spells
                         .Where(spell => spell.count > 3))
            {
                Debug.Log(spell.count);
            }
            
            m_target = target;
            m_attackTime = attackTime;
            m_spellCaster = new SpellCaster(transform, true);
            
            m_isInitialized = true;
        }

        private void Update()
        {
            if (!m_isInitialized)
            {
                return;
            }

            if (m_cooldownTimer > 0)
            {
                m_cooldownTimer -= Time.deltaTime;
            }
        }
        
        public bool TryAttack()
        {
            if (!m_isInitialized || !m_target)
            {
                return false;
            }

            if (m_cooldownTimer > 0)
            {
                return false;
            }
            
            //m_spellCaster.Cast(m_spell, m_target.position);
            m_cooldownTimer = m_attackTime;
            
            return true;
        }
    }
}