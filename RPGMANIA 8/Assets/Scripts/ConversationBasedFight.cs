using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


namespace Playable.Entities.Battle
{
    [CommandInfo("Player", "Start Combat", "This starts a combat during a conversation")]
    public class ConversationBasedFight : Command
    {
        public GameObject[] Enemies;

        public override void Execute()
        {
            BattleZone zone = BattleManager.instance.zone;

            foreach (var enemy in Enemies)
                zone.SpawnInZone(enemy);

            BattleManager.instance.BattleStart();
            gameObject.SetActive(false);

            Continue();
        }
    }
}