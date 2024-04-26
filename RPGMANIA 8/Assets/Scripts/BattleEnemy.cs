using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Playable.Entities.Battle
{
    using Stats;
    using Playable.Entities;
    using Playable.Entities.Player;

    public class BattleEnemy : EntityBase
    {
        [SerializeField]
        Loot Loot; 

        [SerializeField]
        EnemyStatsRef Stats;
        [SerializeField]
        SpriteRenderer HealthSprite;
        [SerializeField]
        Outline UnitOutline;
        public bool Selected {
            get => BattleManager.instance.SelectedUnit == this; 
        }
        private void Awake()
        {
            stats = Stats; 

            CurrentHealth = MaxHealth = Stats.MaxHealth;
            var player = FindObjectOfType<PlayerMovement>().transform.position;

            transform.LookAt(new Vector3(player.x, FindObjectOfType<PlayerMovement>().GetComponent<Collider>().bounds.min.y, player.z)); 
        }

        public override void OnDamageTaken(int amount)
        {
            base.OnDamageTaken(amount);
            float x = ((float)MaxHealth - ((float)MaxHealth - (float)CurrentHealth)) / (float)MaxHealth;
            HealthSprite.size = new Vector2(x, 1);
        }

        public override void BasicAttack(EntityBase Target, int damage)
        {
            base.BasicAttack(Target, damage);
            BattleManager.instance.EndTurn(); 
        }

        public override void OnDeath()
        {

            BattleManager.instance.RemoveFromTurnOrder(this);
            Destroy(gameObject);
        }

        private void Update()
        {
            UnitOutline.OutlineWidth = Selected ? 6 : 1;
        }
    }
}