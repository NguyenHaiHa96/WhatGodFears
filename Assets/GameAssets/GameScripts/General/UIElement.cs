using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement : GameUnit
{
    private RectTransform rectTransform;

    public RectTransform RectTransform
    {
        get
        {
            if (rectTransform == null)
            {
                rectTransform = gameObject.GetComponent<RectTransform>(); ;
            }
            return rectTransform;
        }
    }

    public Vector3 AnchoredPosition { get => RectTransform.anchoredPosition; set => RectTransform.anchoredPosition = value; }
    public Vector3 SizeDelta { get => RectTransform.sizeDelta; set => RectTransform.sizeDelta = value; }
}