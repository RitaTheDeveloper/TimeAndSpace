using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropPlanet : MonoBehaviour
{

    private Vector3 mousePosition;
    private float mass;

    private Vector3 getMousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        mass = GetComponent<Rigidbody>().mass;
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
