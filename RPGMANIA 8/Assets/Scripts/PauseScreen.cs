using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    using Playable;
    using Stats;
    using TMPro;
    using UnityEngine.UI;

    public class PauseScreen : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI Health, Level, Speed, Attack, Defense, Special, Experience;
        [SerializeField]
        PlayerStatsRef Stats;
        [SerializeField]
        Button CloseButton, ExitButton;


        private void Awake()
        {
            ExitButton.onClick.AddListener(() => GameState.instance.Quit());
            CloseButton.onClick.AddListener(() => GameState.instance.Pause()); 
        }

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