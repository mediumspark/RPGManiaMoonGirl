using Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Playable.Entities.Battle
{
    public class SpecialAttacks : ScriptableObject
    {
        public int BaseValue, lunarCost;
        public GameObject SpecialEffectParticles;
        public string Description; 

        public virtual void Assign(UnityEvent onCast, EntityBase target) {
            onCast.AddListener(() => ParticleEffect(target));
        }
        public virtual void Assign(UnityEvent onCast, List<EntityBase> target) {
            onCast.AddListener(() => ParticleEffects(target));
        }

        public virtual void ParticleEffect(EntityBase target)
        {
            try
            {
                Instantiate(SpecialEffectParticles, target.transform);
            }
            catch { }
        }

        public void ParticleEffects(List<EntityBase> target)
        {
            foreach(EntityBase entity in target)
            {
                ParticleEffect(entity);
            }
        }

    }
}