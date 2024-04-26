using UnityEngine;
using UnityEngine.Events;

namespace Playable.Entities.Battle
{
    [CreateAssetMenu(fileName ="Special Attack", menuName = "Special Attack/SingleDamage")]
    public class SingleDamageSpecial : SpecialAttacks
    {
        public override void Assign(UnityEvent onCast, EntityBase target)
        {
            base.Assign(onCast, target);
            onCast.AddListener(() => Damage(target));
        }
        public void Damage(EntityBase entity)
        {
            entity.OnDamageTaken(BaseValue); 
        }
    }
}