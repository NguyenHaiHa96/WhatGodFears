using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGlobalState : State<UICard>
{
    public static CardGlobalState istance = null;
    public static CardGlobalState Instance
    {
        get
        {
            if (istance == null)
            {
                istance = new CardGlobalState();
            }
            //istance ??= new CardGlobalState();
            return istance;
        }
    }

    public override void OnEnter(UICard go)
    {

    }

    public override void OnExecute(UICard go)
    {

    }

    public override void OnExit(UICard go)
    {

    }
}

public class CardInDesk : State<UICard>
{
    public static CardInDesk istance = null;
    public static CardInDesk Instance
    {
        get
        {
            istance ??= new CardInDesk();
            return istance;
        }
    }

    public override void OnEnter(UICard go)
    {
        
    }

    public override void OnExecute(UICard go)
    {

    }

    public override void OnExit(UICard go)
    {

    }
}

public class CardStandbyState : State<UICard>
{
    public static CardStandbyState istance = null;
    public static CardStandbyState Instance
    {
        get
        {
            istance ??= new CardStandbyState();
            return istance;
        }
    }

    public override void OnEnter(UICard go)
    {
        UIManager.Instance.CanvasGameplay.SetCardToStandby(go.TfCard);
        go.TfPlaceHolder.localScale = Vector3.zero;
    }

    public override void OnExecute(UICard go)
    {
        
    }

    public override void OnExit(UICard go)
    {

    }
}

public class CardBackToHandState : State<UICard>
{
    public static CardBackToHandState istance = null;
    public static CardBackToHandState Instance
    {
        get
        {
            istance ??= new CardBackToHandState();
            return istance;
        }
    }
    public override void OnEnter(UICard go)
    {
        this.LogMsg("Back to hand");
    }

    public override void OnExecute(UICard go)
    {

    }

    public override void OnExit(UICard go)
    {

    }
}
