using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;
using DG.Tweening;
using TMPro;

public class UICard : DraggableObject
{
    [Header("UI Card")]
    public RectTransform TfCard;
    public RectTransform TfPlaceHolder;
    public LayoutElement LayoutElement;
    public TextMeshProUGUI TxtOrderInHand;
    public UIHandCard UIHandCard;
    public int OrderInHand;

    [SerializeField] private float additionHeight;

    protected StateMachine<UICard> stateMachine;

    private Vector2 startSizeDelta;
    private Vector2 startAnchoredPosition;
    private Vector2 previewAnchoredPosition; 

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

    public Vector2 StartSizeDelta { get => startSizeDelta; }
    #endregion

    private void Awake()
    {
        startAnchoredPosition = TfCard.anchoredPosition;
        previewAnchoredPosition = new(TfCard.anchoredPosition.x, TfCard.anchoredPosition.y + additionHeight);
        startSizeDelta = SizeDelta;
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
        TfCard.position = eventData.position;   
        if (!InputManager.Instance.CheckIsCardPassedHandThreshold(this))
        {
            stateMachine.ChangeState(CardStandbyState.Instance);
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (!InputManager.Instance.CheckIsCardPassedHandThreshold(this))
        {
            stateMachine.ChangeState(CardInHandState.Instance);
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        stateMachine.ChangeState(CardPreviewState.Instance);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        if (stateMachine.CurrentState == CardPreviewState.Instance)
        {
            stateMachine.ChangeState(CardInHandState.Instance);
        }

    }

    public void DrawFromDrawPile()
    {
        TfPlaceHolder.SetParent(UIManager.Instance.CanvasGameplay.GetHandCardCardsInHandContainer());
        TfCard.position = UIManager.Instance.CanvasGameplay.GetDrawPilePosition().position;
        TfCard.localScale = Vector2.zero;
    }

    public void OnShowPreview()
    {
        TfCard.localScale = Constant.ScaleSize14;
        TfCard.anchoredPosition = previewAnchoredPosition;

    }

    public void OnHidePreview()
    {
        TfCard.localScale = Vector2.one;
        TfCard.anchoredPosition = startAnchoredPosition;
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
