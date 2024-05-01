using Playable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIReference : MonoBehaviour
{
    public static PlayerUIReference Instance;
    public GameObject PauseCanvas, BattleCanvas, DefeatCanvas;
    public Button RestartGame, QuitGame; 

    private void Awake()
    {
        Instance = this;
        GameState.instance.BattleCanvas = BattleCanvas;
        GameState.instance.PauseCanvas = PauseCanvas; 
        GameState.instance.DefeatCanvas = DefeatCanvas;
        RestartGame.onClick.AddListener(() => GameState.instance.ReloadLevel()); 
        QuitGame.onClick.AddListener(() => GameState.instance.LoadLevel("MainMenu"));
    }
}
