using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemData : MonoBehaviour
{
    public int planetIndex;
    public Sprite planetImage;
    public GameObject planetPrefab;


    public void setSprite()
    {
        var Sprite = GetComponent<Image>();
        Sprite.sprite = planetImage;
    }




}
