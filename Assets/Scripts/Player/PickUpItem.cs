using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            itemDetails itemDetails = InventoryManager.Instance.GetItemDetail(item.itemCode);
            if (itemDetails != null)
            {
                Debug.Log(itemDetails.itemDescription);
            }
        }
        
    }
}
