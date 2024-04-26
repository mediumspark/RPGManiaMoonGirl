using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    using Stats;
    using TMPro; 

    public class PauseScreen : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI Health, Level, Speed, Attack, Defense, Special, Experience;
        [SerializeField]
        PlayerStatsRef Stats; 

        private void Update()
        {
            Level.text = $"{Stats.Level}";
            Experience.text = $"{Stats.Experience} / {Stats.ExperienceToLevel}";

            Health.text = $"{Stats.CurrentHealth} /  {Stats.MaxHealth}";
            Attack.text = $"{Stats.Attack}";
            Defense.text = $"{Stats.Defense}";
            Special.text = $"{Stats.Special}";
            Speed.text = $"{Stats.Speed}";

        }

    }
}