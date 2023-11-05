using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropPlanet : MonoBehaviour
{

    private Vector3 mousePosition;
    private float mass;
    private Vector3 startPosition;

    private List<GameObject> pointedObject()
    {
        List<GameObject> gameObjectList = new List<GameObject>();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] allHits;
        allHits = Physics.RaycastAll(ray);
        for (int i = 0; i < allHits.Length; i++)
        {
            gameObjectList.Add(allHits[i].transform.gameObject);
        }
        return gameObjectList;
    }

    private Vector3 getMousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        mass = GetComponent<Rigidbody>().mass;
        startPosition = transform.position;
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody>().mass = mass;
        foreach (var obj in pointedObject())
        {
            if (obj.name != "Plane" && obj.name != gameObject.name)
            {
                transform.position = startPosition;
            }
        }
    }
    
    
    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().mass = 0;
        mousePosition = Input.mousePosition - getMousePosition();
        
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
