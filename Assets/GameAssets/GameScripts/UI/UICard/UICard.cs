using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;
using TMPro;
using UnityEditor;

public class UICard : DraggableObject
{
    [Header("UI Card")]
    public Transform TfPlaceHolder;
    public Transform TfCard;
    public LayoutElement LayoutElement;
    public TextMeshProUGUI TxtOrderInHand;
    public UIHandCard UIHandCard;
    public int OrderInHand;

    [ShowInInspector]
    protected StateMachine<UICard> stateMachine;

    [Button]
    private void SetPreferredWidthAndHeight()
    {
        EditorUtility.SetDirty(this);
        LayoutElement.preferredWidth = SizeDelta.x;
        LayoutElement.preferredHeight = SizeDelta.y;
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    #region Getter Setter
    public StateMachine<UICard> StateMachine { get { return stateMachine; } }
    #endregion

    private void Awake()
    {
        InitStateMachine();
    }
    protected virtual void InitStateMachine()
    {
        stateMachine = new StateMachine<UICard>(this);
        stateMachine.SetCurrentState(CardInDesk.Instance);
        stateMachine.SetGlobalState(CardGlobalState.Instance);
        stateMachine.CurrentState.OnEnter(this);
    }

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
