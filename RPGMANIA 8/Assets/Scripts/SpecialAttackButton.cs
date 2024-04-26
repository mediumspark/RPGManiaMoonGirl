using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UI
{
    using UnityEngine.UI;
    using Playable.Entities.Battle;
    using TMPro;

#if UNITY_EDITOR
    using UnityEditor;
    using Stats;

    [CustomEditor(typeof(SpecialAttackButton))]
    public class SpecialAttackButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            SpecialAttackButton targetButton = (SpecialAttackButton)target;
            // Draw custom fields
            targetButton.special = (SpecialAttacks)EditorGUILayout.ObjectField("Special Attack", targetButton.special, typeof(SpecialAttacks), true);
            targetButton.hintBox = (GameObject)EditorGUILayout.ObjectField("Special Hint", targetButton.hintBox, typeof(GameObject), true);

            // Draw specific inherited fields
            targetButton.interactable = EditorGUILayout.Toggle("Interactable", targetButton.interactable);
            // Draw Transition property
            targetButton.transition = (Selectable.Transition)EditorGUILayout.EnumPopup("Transition", targetButton.transition);
            if (targetButton.transition == Selectable.Transition.ColorTint)
            {
                var colors = targetButton.colors;
                colors.normalColor = EditorGUILayout.ColorField("Normal Color", colors.normalColor);
                colors.highlightedColor = EditorGUILayout.ColorField("Highlighted Color", colors.highlightedColor);
                colors.pressedColor = EditorGUILayout.ColorField("Pressed Color", colors.pressedColor);
                colors.selectedColor = EditorGUILayout.ColorField("Selected Color", colors.selectedColor);
                colors.disabledColor = EditorGUILayout.ColorField("Disabled Color", colors.disabledColor);
                colors.colorMultiplier = EditorGUILayout.FloatField("Color Multiplier", colors.colorMultiplier);
                colors.fadeDuration = EditorGUILayout.FloatField("Fade Duration", colors.fadeDuration);
                targetButton.colors = colors;
            }
            // Draw OnClick events
            SerializedProperty onClickProperty = serializedObject.FindProperty("m_OnClick");
            EditorGUILayout.PropertyField(onClickProperty);

            // Apply changes
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
    public class SpecialAttackButton : Button
    {
        public SpecialAttacks special;
        public GameObject hintBox;
        public TextMeshProUGUI hintText; 

        public void Create()
        {
            special.Assign(onClick, BattleManager.instance.SelectedUnit);
            special.Assign(onClick, BattleManager.instance.SpawnedEnemies);
            onClick.AddListener(() => PlayerRef.instance.Stats.CurrentLunarPhase -= special.lunarCost);
            onClick.AddListener(() => FindObjectOfType<SpecialAttackListUI>().gameObject.SetActive(false));
        }

        private void Update()
        {
            interactable = PlayerRef.instance.Stats.CurrentLunarPhase >= special.lunarCost;
            if (!interactable)
                return; 

            hintBox.SetActive(IsHighlighted()); 
            if (IsHighlighted())
            {
                hintText.text = special.Description; 
            }
        }
    }
}