using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector3 offset;
    private Vector3 startPosition;
    private bool isDragging = false;

    private GameObject planetPrefab;

    void Start()
    {
        startPosition = transform.position; // Замените на путь к вашему префабу планеты
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter.gameObject.GetComponent<ItemData>().planetPrefab != null)
        {
            planetPrefab = eventData.pointerEnter.gameObject.GetComponent<ItemData>().planetPrefab;
        }
        Debug.Log(eventData.pointerEnter.gameObject.name);
        isDragging = true;
        transform.position = Input.mousePosition + offset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        offset = transform.position - Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    
            isDragging = false;
            transform.position = startPosition;
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000))
            {
                GameObject newPlanet = Instantiate(planetPrefab, hit.point, Quaternion.identity);
                Debug.Log("hop");
            }
        Destroy(eventData.pointerEnter);
                          
    }
}
