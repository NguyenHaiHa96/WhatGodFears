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
    public Transform TfCard;
    public Transform TfPlaceHolder;
    public RectTransform RectTfCard;
    public RectTransform RectTfPlaceHolder;
    public LayoutElement LayoutElement;
    public TextMeshProUGUI TxtOrderInHand;
    public UIHandCard UIHandCard;
    public int OrderInHand;

    [SerializeField] private float additionHeight;

    protected StateMachine<UICard> stateMachine;

    [SerializeField] private Vector2 cardDefaultAnchoredPosition;
    private Vector2 cardPreviewAnchoredPosition;
    private Vector2 placeHolderStartSizeDelta;
    private Vector2 placeHolderDefaultSizeDelta;

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
        Setup();
    }

    public virtual void Setup()
    {
        SetStartingPosition();
        InitStateMachine();
    }

    public virtual void SetStartingPosition()
    {
        placeHolderDefaultSizeDelta = SizeDelta;
        //placeHolderStartSizeDelta = new(0, SizeDelta.y);
        cardPreviewAnchoredPosition = new(RectTfCard.anchoredPosition.x, RectTfCard.anchoredPosition.y + additionHeight);
    }

    public virtual void InitStateMachine()
    {
        stateMachine = new StateMachine<UICard>(this);
        stateMachine.SetCurrentState(CardInDesk.Instance);
        stateMachine.SetGlobalState(CardGlobalState.Instance);
        stateMachine.CurrentState.OnEnter(this);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        RectTfCard.position = eventData.position;   
        if (!InputManager.Instance.CheckIsCardPassedHandThreshold(this))
        {
            stateMachine.ChangeState(CardStandbyState.Instance);
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        //if (!InputManager.Instance.CheckIsCardPassedHandThreshold(this))
        //{
        //    stateMachine.ChangeState(CardInHandState.Instance);
        //}
        //else
        //{

        //}
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
        RectTfPlaceHolder.SetParent(UIManager.Instance.CanvasGameplay.GetHandCardCardsInHandContainer());
        //SizeDelta = placeHolderStartSizeDelta;
        //TfCard.SetParent(UIManager.Instance.CanvasGameplay.GetUIDrawPile().Transform);
        //TfCard.position = UIManager.Instance.CanvasGameplay.GetUIDrawPile().WorldPosition;
        //TfCard.localEulerAngles = Constant.Rotate90 * -1;
        //TfCard.localScale = Vector2.zero;  
        //RectTfPlaceHolder.DOSizeDelta(placeHolderDefaultSizeDelta, Constant.TimeDuration05).OnUpdate(() =>
        //{
        //    Canvas.ForceUpdateCanvases();
        //});
        //TfCard.DOScale(Vector2.one, Constant.TimeDuration066);
        //TfCard.DORotate(Vector2.one, Constant.TimeDuration066);
    }

    public void OnShowPreview()
    {
        RectTfCard.localScale = Constant.ScaleSize12;
        RectTfCard.anchoredPosition = cardPreviewAnchoredPosition;

    }

    public void OnHidePreview()
    {
        RectTfCard.localScale = Vector2.one;
        RectTfCard.anchoredPosition = RectTfPlaceHolder.anchoredPosition;
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
