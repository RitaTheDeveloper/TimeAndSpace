using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float _gravityConst = 0.67f;

    [SerializeField] private GameObject[] _planets;

    private Rigidbody _rigidbody;
    private float _distance;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

    }

    public void SetArrayOfPlanets(GameObject[] planets)
    {
        _planets = planets;
    }

    public void CalculationOfPlanetaryGravityOnTheShip()
    {
        for (int i = 0; i < _planets.Length; ++i)
        {
            _distance = Vector3.Distance(transform.position, _planets[i].transform.position);
            _rigidbody.AddForce(((_planets[i].transform.position - transform.position) / _distance) * (_rigidbody.mass * _planets[i].GetComponent<Rigidbody>().mass * _gravityConst) / (_distance * _distance + 1));
        }
    }
}
