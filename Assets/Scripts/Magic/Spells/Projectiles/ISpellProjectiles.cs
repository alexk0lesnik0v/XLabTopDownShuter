using UnityEngine;
using Magic.Effects;
using System.Collections.Generic;

namespace Magic.Spells.Projectiles
{
    public interface ISpellProjectiles
    {
        public void Initialize(Vector3 targetPosition, float speed, IReadOnlyList<IEffect> effects);
    }
}