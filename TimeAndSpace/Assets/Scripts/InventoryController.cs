using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    private ItemData[] items;

    // Start is called before the first frame update
    void Start()
    {
        items = GetComponentsInChildren<ItemData>();
        DrawInventory();
    }

    void DrawInventory()
    {
        foreach (ItemData item in items)
        {
            item.setSprite();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
