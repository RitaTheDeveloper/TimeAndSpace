using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenController : MonoBehaviour
{
    [SerializeField] private SpaceshipController spaceshipController;
    [SerializeField] private float _maxOxygen = 100f;
    [SerializeField] private float _oxygenFallRate = 10f;
    private float _currentOxygen;

    private void Start()
    {
        _currentOxygen = _maxOxygen;
    }

    private void FixedUpdate()
    {
        DescreaceInOxygenInFrame();
    }
    private void DescreaceInOxygenInFrame()
    {
        if (_currentOxygen <= 0f)
        {
            GameManager.instance.GameOver();
            spaceshipController.Death();
        }
        else
        {
            _currentOxygen -= _oxygenFallRate * Time.fixedDeltaTime;
            var currentOxygen = _currentOxygen / _maxOxygen;
            UIManager.instance.DisplayOxygen(currentOxygen);
        }
    }

    public void AddOxygen(float amountOfOxygen)
    {
        _currentOxygen += amountOfOxygen;

        if (_currentOxygen > _maxOxygen)
        {
            _currentOxygen = _maxOxygen;
        }
    }
}
