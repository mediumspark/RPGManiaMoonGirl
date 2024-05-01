using Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Playable.Entities
{
    public interface Entity
    {
        public void OnDamageTaken(int amount);
        public void OnHeal(int amount);
        public void OnDeath(); 
    }

    public interface IInteractable
    {
        public void OnInteract(); 
    }

    public interface IOnTriggerInteract
    {
        public void OnTriggerInteract();
    }



    public class  EntityBase : MonoBehaviour, Entity
    {
        [HideInInspector]
        public StatsRef stats { get; set; }

        [Serializable]
        public struct Attack
        {
            public int Damage;
            public GameObject Effect;

            public void DoDamage(EntityBase Target)
            {
                Target.OnDamageTaken(Damage);
                Instantiate(Effect, Target.transform); 
            }
        }

        public Attack BasicAttack;

        public virtual int CurrentHealth { get; set; }
        public virtual int MaxHealth { get; set; }

        public virtual void PerformBasicAttack(EntityBase Target)
        {
            BasicAttack.DoDamage(Target); 
        }

        public virtual void OnDamageTaken(int amount)
        {
            CurrentHealth -= amount;
            if (CurrentHealth <= 0)
                OnDeath();
        }

        public virtual void OnDeath()
        {

        }

        public virtual void OnHeal(int amount)
        {
            CurrentHealth += amount;
            if (CurrentHealth >= MaxHealth)
                CurrentHealth = MaxHealth;
        }
    }
}