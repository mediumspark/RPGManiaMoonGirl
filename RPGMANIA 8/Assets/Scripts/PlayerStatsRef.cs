using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    using Playable.Entities.Battle; 
#if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(PlayerStatsRef))]
    public class PlayerStatsRefEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var Preft = target as PlayerStatsRef;
            if(GUILayout.Button("Reset Player"))
            {
                Preft.Rest(); 
            }
        }
    }

#endif

    [System.Serializable]
    public struct SpecialAttackEntry
    {
        public SpecialAttacks special;
        public bool Unlocked;
    }

    [CreateAssetMenu(fileName ="Player", menuName ="Player (Only make one)")]
    public class PlayerStatsRef : StatsRef
    {
        public int CurrentHealth;
        public const int LunarPercentToNextPhase = 100; 
        public int CurrentLunarPercent, CurrentLunarPhase;
        public AllyStatsRef TeamMateOne, TeamMateTwo;
        public List<AllyStatsRef> Allies;
        public List<SpecialAttackEntry> SpecialAttacks;
        public int Experience, ExperienceToLevel; 
        public void Rest()
        {
            CurrentHealth = MaxHealth;
            CurrentLunarPercent = 0; 
            CurrentLunarPhase = 0;
        }
    }


}