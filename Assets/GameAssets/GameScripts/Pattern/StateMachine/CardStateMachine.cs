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
            istance ??= new CardGlobalState();
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
        UIManager.Instance.CanvasGameplay.SetCardToStandby(go.RectTfCard);
        go.RectTfPlaceHolder.sizeDelta = Vector2.zero;
    }

    public override void OnExecute(UICard go)
    {
        
    }

    public override void OnExit(UICard go)
    {

    }
}

public class CardPreviewState : State<UICard>
{
    public static CardPreviewState istance = null;
    public static CardPreviewState Instance
    {
        get
        {
            istance ??= new CardPreviewState();
            return istance;
        }
    }

    public override void OnEnter(UICard go)
    {
        go.OnShowPreview();
    }

    public override void OnExecute(UICard go)
    {
        
    }

    public override void OnExit(UICard go)
    {
        go.OnHidePreview();
    }
}

public class CardOnDrawFromDrawPileState : State<UICard>
{
    public static CardOnDrawFromDrawPileState istance = null;
    public static CardOnDrawFromDrawPileState Instance
    {
        get
        {
            istance ??= new CardOnDrawFromDrawPileState();
            return istance;
        }
    }

    public override void OnEnter(UICard go)
    {
        go.DrawFromDrawPile();
    }

    public override void OnExecute(UICard go)
    {
        
    }

    public override void OnExit(UICard go)
    {
        
    }
}

public class CardInHandState : State<UICard>
{
    public static CardInHandState istance = null;
    public static CardInHandState Instance
    {
        get
        {
            istance ??= new CardInHandState();
            return istance;
        }
    }

    public override void OnEnter(UICard go)
    {
        go.RectTfCard.position = go.RectTfPlaceHolder.position;
    }

    public override void OnExecute(UICard go)
    {

    }

    public override void OnExit(UICard go)
    {

    }
}
