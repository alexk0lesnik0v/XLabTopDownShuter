using System.Collections;
using Magic.Spells.Data;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace Magic.Systems
{
    public class SpellCaster
    {
        private Transform m_casterTransform;
        
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
                case AoeSpellData aoeSpell: CastAoe(aoeSpell, worldPosition);
                    break;
            }
        }
        
        private void CastSelf(SelfSpellData spell) { }
        
        private void CastTarget(TargetSpellData spell, Vector3 worldPosition) { }
        
        private void CastNonTarget(NonTargetSpellData spell) { }
        
        private void CastAoe(AoeSpellData spell,  Vector3 worldPosition) { }
    }
}