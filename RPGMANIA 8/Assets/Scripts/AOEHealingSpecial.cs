using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Playable.Entities.Battle
{
    [CreateAssetMenu(fileName = "Special Attack", menuName = "Special Attack/All Heal")]
    public class AOEHealingSpecial : SpecialAttacks
    {
        public override void Assign(UnityEvent onCast, List<EntityBase> target)
        {
            base.Assign(onCast, target);
            onCast.AddListener(() => Heal(target));
        }

        public void Heal(List<EntityBase> entity)
        {
            foreach (var e in entity)
            {
                e.OnHeal(BaseValue);
            }
        }
    }
}