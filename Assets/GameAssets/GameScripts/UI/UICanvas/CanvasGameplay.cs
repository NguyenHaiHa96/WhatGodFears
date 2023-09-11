using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameplay : UICanvas
{
    [Header("Canvas Gameplay")]
    public UIHandCard UIHandCard;

    public Transform GetHandCardThreshold() => UIHandCard.TfThreshold;

    public Transform GetHandCardCardContainer() => UIHandCard.TfCardContainer;
}
