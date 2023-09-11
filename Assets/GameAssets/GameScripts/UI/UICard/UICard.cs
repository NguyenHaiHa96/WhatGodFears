using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;
using TMPro;

public class UICard : DraggableObject
{
    [Header("UI Card")]
    public UIHandCard UIHandCard;
    public TextMeshProUGUI TxtOrderInHand;
    public int OrderInHand;

    [ShowInInspector]
    protected StateMachine<UICard> stateMachine;

    #region Getter Setter
    public StateMachine<UICard> StateMachine { get { return stateMachine; } }
    #endregion

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        if (!InputManager.Instance.CheckIsCardPassedHandThreshold(this))
        {
            stateMachine.ChangeState(CardStandbyState.Instance);
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (!InputManager.Instance.CheckIsCardPassedHandThreshold(this))
        {
            stateMachine.ChangeState(CardBackToHandState.Instance);
        }
    }

    #region Test
    public void SetOrder(int order, UIHandCard ui_HandCard)
    {
        UIHandCard = ui_HandCard;
        OrderInHand = order;
        TxtOrderInHand.SetText("{0}", OrderInHand);
    }
    #endregion
}
