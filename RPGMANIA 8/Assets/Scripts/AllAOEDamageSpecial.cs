using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Playable.Entities.Battle
{
    [CreateAssetMenu(fileName = "Special Attack", menuName = "Special Attack/All Damage AOE")]
    public class AllAOEDamageSpecial : SpecialAttacks
    {
        public override void Assign(UnityEvent onCast, List<EntityBase> target)
        {
            base.Assign(onCast, target);
            onCast.AddListener(() => Damage(target));
        }
        public void Damage(List<EntityBase> entities) 
        {
            foreach (EntityBase entity in entities)
            {
                entity.OnDamageTaken(BaseValue);
            }
        }
    }
}