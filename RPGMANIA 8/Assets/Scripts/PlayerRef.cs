using Playable;
using Playable.Entities;
using Playable.Entities.Player;
using Stats;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;


namespace Stats
{
    public class PlayerRef : EntityBase
    {
        public static PlayerRef instance; 
        [SerializeField]
        PlayerStatsRef PlayerStats;
        [SerializeField]
        PlayerBag Bag;
        public bool Defending;
        [HideInInspector]
        public PlayerMovement Playerlocation; 
        public override int CurrentHealth { get => PlayerStats.CurrentHealth; set => PlayerStats.CurrentHealth = value; }
        public override int MaxHealth { get => PlayerStats.MaxHealth; set => PlayerStats.MaxHealth = value; }
        public PlayerStatsRef Stats => PlayerStats;

        public Vector3 PlayerPos
        {
            get
            {
                var player = FindObjectOfType<PlayerMovement>().transform.position;
                return new Vector3(player.x, FindObjectOfType<PlayerMovement>().GetComponent<Collider>().bounds.min.y, player.z);
            }
        }

        private void Awake()
        {
            instance = this;
            stats = PlayerStats;
            BasicAttack.Damage += PlayerStats.Attack;
        }

        public override void OnDamageTaken(int amount)
        {
            if((PlayerStats.CurrentLunarPhase > 0 || PlayerStats.CurrentLunarPercent > 0) && Defending)
            {
                DecreaseLunarGauge(amount);
                return;
            }

            base.OnDamageTaken(amount);

        }

        private void Update()
        {
            try
            {
                transform.position = Playerlocation.transform.position;
            }
            catch { }
        }

        public void IncreaseLunarCharge()
        {
            switch (PlayerStats.CurrentLunarPhase)
            {
                case 0:
                    PlayerStats.CurrentLunarPercent += 20;
                    break;
                case 1:
                    PlayerStats.CurrentLunarPercent += 10;
                    break;
                case 2:
                    PlayerStats.CurrentLunarPercent += 5;
                    break;
                case 3:
                    PlayerStats.CurrentLunarPercent += 2;
                    break;
                case 4:
                    Debug.Log("Death");
                    break;

                default:
                    PlayerStats.CurrentLunarPhase = 4; 
                    break;
            }

            if (PlayerStats.CurrentLunarPercent >= 100)
            {
                PlayerStats.CurrentLunarPercent -= 100;
                PlayerStats.CurrentLunarPhase++;
            }
        }


        public void DecreaseLunarGauge(int amount)
        {
            if (PlayerStats.CurrentLunarPhase == 0 && PlayerStats.CurrentLunarPercent - amount <= 0)
            {
                PlayerStats.CurrentLunarPercent = 0;
                return;
            }

            PlayerStats.CurrentLunarPercent -= amount;

            if (PlayerStats.CurrentLunarPhase > 0 && PlayerStatsRef.LunarPercentToNextPhase < 0)
            {
                PlayerStats.CurrentLunarPhase--;
                PlayerStats.CurrentLunarPercent += 100;
            }
        }

        public override void OnDeath()
        {
            GameState.instance.DefeatCanvas.SetActive(true); 
        }
    }

    public class StatsRef : ScriptableObject
    {
        public int Level;
        public int MaxHealth;
        public int Speed;
        public int Attack;
        public int Defense;
        public int Special; 
    }

    [CreateAssetMenu(fileName ="Ally", menuName ="Allies")]
    public class AllyStatsRef : StatsRef
    {

    }
}