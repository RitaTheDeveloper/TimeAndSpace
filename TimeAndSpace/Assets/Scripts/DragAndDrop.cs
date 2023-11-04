using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    Vector3 offset;

    void Awake()
    {
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + offset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        offset = transform.position - Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}