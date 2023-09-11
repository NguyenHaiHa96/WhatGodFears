using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : GameUnit, IDragHandler
{
    public virtual void OnDrag(PointerEventData eventData)
    {
        WorldPosition = eventData.position; 
    }
}
