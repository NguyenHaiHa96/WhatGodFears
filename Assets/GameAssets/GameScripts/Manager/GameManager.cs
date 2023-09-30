using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : GameSingleton<GameManager>
{
    [Title("Game Manager", "Build Status")]
    public BuildStatus BuildStatus;
    public GameState GameState;
    public GameMode GameMode;

    public override void Awake()
    {
        base.Awake();
        OnInit();
    }

    public override void OnInit()
    {
        base.OnInit();
        UIManager.Instance.FetchData(); 
        HeroController.Instance.FetchData();
        EnemyController.Instance.FetchData();
        LevelManager.Instance.FetchData();
        ChangeState(GameState.Gameplay);
    }

    public void ChangeState(GameState state)
    {
        GameState = state;
    }
}
