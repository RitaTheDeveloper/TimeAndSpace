﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _goBtn;

    [SerializeField] private GameObject _oxygenBar;

    private void Awake()
    {
        instance = this;
    }

    public void DisplayOxygen(float _currentOxygen)
    {
        _oxygenBar.GetComponent<Slider>().value = _currentOxygen;
    }

    private void AllOff()
    {
        _mainMenu.SetActive(false);
        _gameMenu.SetActive(false);
    }

    public void OnClickStartNewGame()
    {
        AllOff();
        _gameMenu.SetActive(true);
    }

    public void OnClickGo()
    {
        GameManager.instance.StartLevel();
        _goBtn.SetActive(false);
    }
}
