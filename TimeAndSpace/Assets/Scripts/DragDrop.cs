using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector3 offset;
    private Vector3 startPosition;
    private bool isDragging;
    private GameObject planetPrefab;

    void Start()
    {
        isDragging = false;
        startPosition = transform.position; // Замените на путь к вашему префабу планеты
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
        Debug.Log(eventData.pointerEnter);
        if (eventData.pointerEnter.gameObject.GetComponent<ItemData>().planetPrefab != null)
        {
            planetPrefab = eventData.pointerEnter.gameObject.GetComponent<ItemData>().planetPrefab;
        }
        transform.position = Input.mousePosition + offset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        offset = transform.position - Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging) 
        {
            transform.position = startPosition;
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.tag == "plane")
                {
                    Instantiate(planetPrefab, hit.point, Quaternion.identity);
                }

            }
            Destroy(eventData.pointerEnter);
        }
        isDragging = false;
    }
}
