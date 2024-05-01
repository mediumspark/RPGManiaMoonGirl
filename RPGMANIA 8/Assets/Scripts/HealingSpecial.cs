using Stats;
using UnityEngine;
using UnityEngine.Events;

namespace Playable.Entities.Battle
{
    [CreateAssetMenu(fileName = "Special Attack", menuName = "Special Attack/Heal")]
    public class HealingSpecial : SpecialAttacks
    {
        public override void Assign(UnityEvent onCast, EntityBase target)
        {
            base.Assign(onCast, target);
            onCast.AddListener(() => Heal(PlayerRef.instance)); 
        }

        public override void ParticleEffect(EntityBase target)
        {
            Instantiate(SpecialEffectParticles, PlayerRef.instance.PlayerPos, Quaternion.identity);
        }

        public void Heal(EntityBase entity)
        {
            entity.OnHeal(BaseValue);
        }
    }
}