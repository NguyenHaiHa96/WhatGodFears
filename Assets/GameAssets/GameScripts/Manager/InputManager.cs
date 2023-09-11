using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : GameSingleton<InputManager> 
{
    public bool CheckIsCardPassedHandThreshold(UICard ui_Card)
    {
        if (ui_Card.WorldPosition.y > UIManager.Instance.CanvasGameplay.GetHandCardThreshold().position.y)
        {
            this.LogMsg("Pass");
        }
        return false;
    }
}
