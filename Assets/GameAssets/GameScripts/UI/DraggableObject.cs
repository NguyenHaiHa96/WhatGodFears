using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : GameUnit, IDragHandler, IEndDragHandler
{
    public virtual void OnDrag(PointerEventData eventData)
    {
        WorldPosition = eventData.position; 
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
