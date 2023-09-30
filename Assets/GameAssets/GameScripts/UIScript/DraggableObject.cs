using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : UIElement, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public virtual void OnDrag(PointerEventData eventData)
    {
       
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {

    }
}
