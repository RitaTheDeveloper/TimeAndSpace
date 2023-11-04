using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData")]
public class ItemData : ScriptableObject
{
    public int planetIndex;
    public Sprite planetImage;
    public GameObject planetPrefab;

}
