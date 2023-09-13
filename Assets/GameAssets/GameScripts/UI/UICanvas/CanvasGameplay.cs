using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameplay : UICanvas
{
    [Header("Canvas Gameplay")]
    public UIHandCard UIHandCard;
    public UIDrawPile UIDrawPile;

    public Transform GetHandCardThreshold() => UIHandCard.TfThreshold;
    public Transform GetHandCardCardsInHandContainer() => UIHandCard.TfCardsInHandContainer;
    public UIDrawPile GetUIDrawPile() => UIDrawPile;

    public void SetCardToStandby(Transform card)
    {
        card.SetParent(UIHandCard.TfCardStandbyContainer);
    }
}
