using System;
using UnityEngine;
using Magic.Effects;
using Magic.Spells.Aoe;
using Magic.Spells.Data;
using Magic.Spells.Projectiles;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Magic.Systems
{
    public sealed class SpellCaster
    {
        private bool m_isSingleSpell;
        private readonly Transform m_casterTransform;
        private ObjectPool<GameObject> m_visualEffectPool;

        public SpellCaster(Transform casterTransform, bool isSingleSpell = false)
        {
            m_isSingleSpell = isSingleSpell;
            m_casterTransform = casterTransform;
        }
        
        public void Cast(BaseSpellData spell, Vector3 worldPosition)
        {
            if (!spell)
            {
                return;
            }

            switch (spell)
            {
                case SelfSpellData selfSpell: CastSelf(selfSpell);
                    break;
                case TargetSpellData targetSpell: CastTarget(targetSpell, worldPosition);
                    break;
                case NonTargetSpellData nonTargetSpell: CastNonTarget(nonTargetSpell);
                    break;
                case AoeSpellData aoeSpell:
                {
                    if (aoeSpell.IsTarget)
                    {
                        CastAoe(aoeSpell, worldPosition);
                    }
                    else
                    {
                        CastAoe(aoeSpell, m_casterTransform.position);
                    }
                }
                    break;
            }
        }

        private void CastSelf(SelfSpellData selfSpell)
        {
            if (selfSpell.visualEffect)
            {
                var visualEffect = Object.Instantiate(selfSpell.visualEffect, m_casterTransform.position, Quaternion.identity);
                SetLayer(visualEffect);
            }

            if (m_casterTransform.TryGetComponent<IEffectable>(out var effectable))
            {
                foreach (var effect in selfSpell.effects)
                {
                    effect.Apply(effectable);
                }
            }
        }

        private void CastTarget(TargetSpellData targetSpell, Vector3 worldPosition)
        {
            if (!targetSpell.visualEffect)
            {
                throw new NullReferenceException("Target spell must have visualEffect");
            }
            
            var projectile = Object.Instantiate(targetSpell.visualEffect, m_casterTransform.position, Quaternion.identity);
            SetLayer(projectile);
            
            var spellProjectile = 
                projectile.GetComponent<ISpellProjectile>() ??
                projectile.AddComponent<SpellProjectile>();
            
            spellProjectile.Initialize(worldPosition, targetSpell.speed, targetSpell.effects);
        }

        private void CastNonTarget(NonTargetSpellData nonTargetSpell)
        {
            
        }

        private void CastAoe(AoeSpellData aoeSpell, Vector3 worldPosition)
        {
            if (!m_isSingleSpell)
            {
                m_visualEffectPool ??=  new ObjectPool<GameObject>( 
                    createFunc:() => new GameObject("VisualEffect"));
            }
            
            var aoe = aoeSpell.visualEffect
                ? Object.Instantiate(aoeSpell.visualEffect, m_casterTransform.position, Quaternion.identity)
                : new GameObject();
            SetLayer(aoe);
            
            aoe.transform.position = worldPosition;
            
            var spellAoe = 
                aoe.GetComponent<ISpellAoe>() ??
                aoe.AddComponent<SpellAoe>();
            
            spellAoe.Initialize(worldPosition, aoeSpell.radius, aoeSpell.effects);
        }

        private void SetLayer(GameObject visualEffect) => 
            visualEffect.layer = m_casterTransform.gameObject.layer;
    }
}