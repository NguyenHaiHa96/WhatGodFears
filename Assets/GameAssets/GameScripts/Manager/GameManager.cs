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

    public void ChangeState(GameState state)
    {
        GameState = state;
    }
}
