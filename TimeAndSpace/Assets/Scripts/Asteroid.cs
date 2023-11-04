using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spaceship")
        {
            // уничтожить
            collision.gameObject.GetComponent<SpaceshipController>().Death();
        }
    }
}
