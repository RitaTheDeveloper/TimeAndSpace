using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject[] _planets;
    private GameObject _spaceship;

    private void Awake()
    {
        instance = this;
    }

    public void StartLevel()
    {
        FindSpaceship();
        FindPlanets();
        if(_spaceship != null)
        {
            _spaceship.GetComponent<SpaceshipController>().StartMove();
        }
    }


    private void FindSpaceship()
    {
        _spaceship = GameObject.FindGameObjectWithTag("Spaceship");
    }

    private void FindPlanets()
    {
        _planets = GameObject.FindGameObjectsWithTag("Planet");
    }

    public GameObject[] GetArrayOfPlanets()
    {
        return _planets;
    }

    public void Win()
    {
        Debug.Log("Win!");
    }
    
    public void GameOver()
    {
        Debug.Log("GameOver!");
    }

    
}
