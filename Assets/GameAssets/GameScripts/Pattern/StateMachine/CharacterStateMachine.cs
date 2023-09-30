using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGlobalState : State<Character>
{
    public static CharacterGlobalState istance = null;
    public static CharacterGlobalState Instance
    {
        get
        {
            istance ??= new CharacterGlobalState();
            return istance;
        }
    }

    public override void OnEnter(Character go)
    {
        
    }

    public override void OnExecute(Character go)
    {
        
    }

    public override void OnExit(Character go)
    {
        
    }
}

public class CharacterSetupState : State<Character>
{
    public static CharacterSetupState istance = null;
    public static CharacterSetupState Instance
    {
        get
        {
            istance ??= new CharacterSetupState();
            return istance;
        }
    }

    public override void OnEnter(Character go)
    {
        go.SetStartingHP();
    }

    public override void OnExecute(Character go)
    {
        
    }

    public override void OnExit(Character go)
    {
        
    }
}


public class CharacterIdleState : State<Character>
{
    public static CharacterIdleState istance = null;
    public static CharacterIdleState Instance
    {
        get
        {
            istance ??= new CharacterIdleState();
            return istance;
        }
    }

    public override void OnEnter(Character go)
    {
        go.ChangeAnim(Constant.ANIM_IDLE, true);
    }

    public override void OnExecute(Character go)
    {
        
    }

    public override void OnExit(Character go)
    {
        
    }
}
