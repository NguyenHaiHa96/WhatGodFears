using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGlobalState : State<Enemy>
{
    public static EnemyGlobalState istance = null;
    public static EnemyGlobalState Instance
    {
        get
        {
            istance ??= new EnemyGlobalState();
            return istance;
        }
    }

    public override void OnEnter(Enemy go)
    {
        
    }

    public override void OnExecute(Enemy go)
    {
        
    }

    public override void OnExit(Enemy go)
    {
        
    }
}

public class EnemySetupState : State<Enemy>
{
    public static EnemySetupState istance = null;
    public static EnemySetupState Instance
    {
        get
        {
            istance ??= new EnemySetupState();
            return istance;
        }
    }

    public override void OnEnter(Enemy go)
    {
        go.SetStartingHP();
    }

    public override void OnExecute(Enemy go)
    {

    }

    public override void OnExit(Enemy go)
    {

    }
}


public class EnemyIdleState : State<Enemy>
{
    public static EnemyIdleState istance = null;
    public static EnemyIdleState Instance
    {
        get
        {
            istance ??= new EnemyIdleState();
            return istance;
        }
    }

    public override void OnEnter(Enemy go)
    {
        go.ChangeAnim(Constant.ANIM_IDLE, true);
    }

    public override void OnExecute(Enemy go)
    {

    }

    public override void OnExit(Enemy go)
    {

    }
}
