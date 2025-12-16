using System;
using System.Collections.Generic;
using Magic.Data;
using Magic.Elements;
using UnityEngine;

namespace Magic.Systems
{
    public class MagicSystem : MonoBehaviour
    {
        public event Action SpellCancelled;
        public event Action<MagicState> StateChanged;
        public event Action<IReadOnlyList<ElementType>> ElementChanged;
        {
            add => SpellPreparation.ElementChanged
        } 
        
        private MagicState m_state;
        private SpellPreparation m_spellPreparation;

        public MagicState State
        {
            get => m_state;
            private set
            {
                if (m_state != value)
                {
                    m_state = value;
                    StateChanged?.Invoke(m_state);
                }
            }
        }
        
        private SpellPreparation spellPreparation => m_spellPreparation ??= new SpellPreparation(m_config);
        
        [SerializeField] private MagicConfig m_config;

        public void AddElement(ElementType element)
        {
            if (state is MagicState.Cooldown or MagicState.Casting)
            {
                return;
            }
            
            spellPreparation.AddElement(element);
            state = MagicState.Preparation;

        }
        
        public void TryCastSpell()
        {
            if (state is not MagicState.Preparation)
            {
                return;
            }

            if (spellPreparation.TryGetSpell(out var spell))
            {
                state = MagicState.Casting;
                
                //TODO Cast
            }
        }

        public bool TryGetSpell(out BaseSpellData spell)
        {
            spell = null;
            return false;
        }
        
        private void StartCoolDown()
        {
        
        }

        private IEnumerator CooldownRoutine()
        {
            state = MagicState.Cooldown;
            yield return new WaitForSeconds(m_config.cancelCooldown);
            state =  MagicState.Idle;
            
            m_cooldownCoroutine = null;
        }
    }
    
    

    public enum MagicState
    {
        Idle,
        Preparation,
        Cooldown,
        Casting
    }
}