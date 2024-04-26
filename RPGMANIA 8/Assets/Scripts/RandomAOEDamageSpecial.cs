using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Playable.Entities.Battle
{
    [CreateAssetMenu(fileName = "Special Attack", menuName = "Special Attack/Random AOE")]
    public class RandomAOEDamageSpecial : SpecialAttacks
    {
        public int EnemiesToHit;

        public override void Assign(UnityEvent onCast, List<EntityBase> target)
        {
            base.Assign(onCast, target);
            onCast.AddListener(() => Damage(target));
        }

        public void Damage(List<EntityBase> entities)
        {
            for(int i = 0; i < EnemiesToHit; i++)
            {
                entities[Random.Range(0, entities.Count - 1)].OnDamageTaken(BaseValue); 
            }
        }
    }
}