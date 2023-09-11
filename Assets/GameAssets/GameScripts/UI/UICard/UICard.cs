using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICard : DraggableObject
{
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        IsPassedHandThreshold();
    }

    public virtual bool IsPassedHandThreshold()
    {
        if (WorldPosition.y > UIManager.Instance.CanvasGameplay.GetHandCardThreshold().position.y)
        {
            this.LogMsg("Pass");
        }
        return false;
    }
}
