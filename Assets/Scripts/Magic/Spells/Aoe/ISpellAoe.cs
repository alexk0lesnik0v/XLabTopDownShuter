using System.Collections.Generic;
using Magic.Effects;
using UnityEngine;

namespace Magic.Spells.Aoe
{
    public interface ISpellAoe
    {
        public void Initialize(Vector3 worldPosition, float radius, IReadOnlyCollection<IEffect> effects);
    }
}