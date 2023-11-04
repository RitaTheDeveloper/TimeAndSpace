using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenCylinder : MonoBehaviour
{
    [SerializeField] private float _amountOfOxygen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spaceship")
        {
            other.gameObject.GetComponent<OxygenController>().AddOxygen(_amountOfOxygen);

            Destroy(gameObject);
        }
    }

}
