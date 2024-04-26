using Playable.Entities.Battle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Playable.Entities
{
    public class OverWorldEnemy : MonoBehaviour, IOnTriggerInteract
    {
        public GameObject[] EnemyTeam;

        public void OnTriggerInteract()
        {
            BattleZone zone = BattleManager.instance.zone;

            foreach (var enemy in EnemyTeam)
                zone.SpawnInZone(enemy);

            BattleManager.instance.BattleStart();
            gameObject.SetActive(false);

        }
        
    }
}