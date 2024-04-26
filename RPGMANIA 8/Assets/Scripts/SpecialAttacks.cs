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
        }
        public virtual void Assign(UnityEvent onCast, List<EntityBase> target) {
        }

    }
}