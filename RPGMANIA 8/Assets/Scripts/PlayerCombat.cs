using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Playable.Entities.Battle
{
    using Stats;
    using UnityEngine.InputSystem;
    using UnityEngine.UI; 

    public class PlayerCombat : MonoBehaviour
    {
        private PlayerStatsRef PlayerStats;
        [SerializeField]
        Button AttackButton, DefendButton, BurstButton; 

        private void Start()
        {
            PlayerStats = PlayerRef.instance.Stats;
            AttackButton.onClick.AddListener(() => Attack(BattleManager.instance.SelectedUnit)); 
            AttackButton.onClick.AddListener(() => BattleManager.instance.EndTurn()); 
            AttackButton.onClick.AddListener(() => PlayerRef.instance.IncreaseLunarCharge());

            DefendButton.onClick.AddListener(() => PlayerRef.instance.Defending = true);
            DefendButton.onClick.AddListener(() => BattleManager.instance.EndTurn()); 
        }

        public void Attack(EntityBase target) => PlayerRef.instance.PerformBasicAttack(target); 


    }
}