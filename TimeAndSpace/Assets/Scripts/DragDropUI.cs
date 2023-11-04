using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector3 offset;
    private Vector3 startPosition;
    private bool isDragging = false;

    [SerializeField] private GameObject planetPrefab;

    void Start()
    {
        startPosition = transform.position; // Замените на путь к вашему префабу планеты
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
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
            isDragging = false;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, Camera.main.nearClipPlane));
            GameObject newPlanet = Instantiate(planetPrefab, worldPos, Quaternion.identity);
             // Отсоединяем от Canvas
            transform.position = startPosition;
        }
    }
}
