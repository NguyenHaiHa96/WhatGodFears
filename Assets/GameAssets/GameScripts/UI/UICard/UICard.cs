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
        startAnchoredPosition = RectTfCard.anchoredPosition;
        previewAnchoredPosition = new(RectTfCard.anchoredPosition.x, RectTfCard.anchoredPosition.y + additionHeight);
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
        RectTfCard.position = eventData.position;   
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
        RectTfPlaceHolder.SetParent(UIManager.Instance.CanvasGameplay.GetHandCardCardsInHandContainer());
        TfCard.SetParent(UIManager.Instance.CanvasGameplay.GetUIDrawPile().Transform);
        TfCard.position = UIManager.Instance.CanvasGameplay.GetUIDrawPile().WorldPosition;
        TfCard.localEulerAngles = Constant.Rotate90 * -1;
        TfCard.localScale = Vector2.zero;
        Canvas.ForceUpdateCanvases();   
        TfCard.DOMove(TfPlaceHolder.position, Constant.TimeDuration066);
        TfCard.DOScale(Vector2.one, Constant.TimeDuration066);
        TfCard.DORotate(Vector2.one, Constant.TimeDuration066);
    }

    public void OnShowPreview()
    {
        RectTfCard.localScale = Constant.ScaleSize14;
        RectTfCard.anchoredPosition = previewAnchoredPosition;

    }

    public void OnHidePreview()
    {
        RectTfCard.localScale = Vector2.one;
        RectTfCard.anchoredPosition = startAnchoredPosition;
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
