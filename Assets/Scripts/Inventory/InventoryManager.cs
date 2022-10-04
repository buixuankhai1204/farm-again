using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonoBehaviour<InventoryManager>
{
    [SerializeField] private Dictionary<int, itemDetails> itemDetailsDictionary;
    public SO_itemList itemList = null;

    protected override void Awake()
    {
        base.Awake();
        CreateItemDetailsDictionary();

    }

    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, itemDetails>();

        foreach (itemDetails item in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(item.itemCode, item);
        }
    }

    public itemDetails GetItemDetail(int itemCode)
    {
        itemDetails itemDetails;
        itemDetailsDictionary.TryGetValue(itemCode, out itemDetails);
        if (itemDetails != null)
        {
            return itemDetails;
        }

        return null;
    }
}