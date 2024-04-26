using Stats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class SpecialAttackListUI : MonoBehaviour
    {
        public Transform SpecialAttackListContext;
        public SpecialAttackButton SpecialAttackButtonPrefab; 
        public GameObject HintBox;
        public TextMeshProUGUI HintText; 

        private void Awake()
        {
            foreach(var attack in PlayerRef.instance.Stats.SpecialAttacks)
            {
                if (attack.Unlocked)
                {
                    var AttackButton = Instantiate(SpecialAttackButtonPrefab, SpecialAttackListContext);
                    AttackButton.special = attack.special;
                    AttackButton.GetComponentInChildren<TextMeshProUGUI>().text = AttackButton.special.name;
                    AttackButton.hintText = HintText;
                    AttackButton.hintBox = HintBox; 
                    AttackButton.Create();
                }
            }
        }
    }
}