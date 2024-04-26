using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UI
{
    using UnityEngine.UI;
    using Stats;
    using TMPro; 

    public class PlayerUI : MonoBehaviour
    {
        [SerializeField]
        PlayerStatsRef PlayerStats;
        public Image Player;
        public Slider HealthSlider, LunerSlider;
        public TextMeshProUGUI LunarLevel;
       
        private void Update()
        {
            if (PlayerStats != null)
            {
                HealthSlider.maxValue = PlayerStats.MaxHealth;
                HealthSlider.value = PlayerStats.CurrentHealth;
                LunerSlider.maxValue = PlayerStatsRef.LunarPercentToNextPhase;
                LunerSlider.value = PlayerStats.CurrentLunarPercent;
                LunarLevel.text = $"{PlayerStats.CurrentLunarPhase}";
            }
        }
    }
}