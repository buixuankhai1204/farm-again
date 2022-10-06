using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonoBehaviour<InventoryManager>
{
    [SerializeField] private Dictionary<int, itemDetails> itemDetailsDictionary;
    public SO_itemList itemList = null;

    public List<InventoryItem>[] inventoryLists;
    public int[] inventoryListCapacityInArray;
    protected override void Awake()
    {
        base.Awake();
        CreateItemDetailsDictionary();
        CreateInventoryLists();

    }

    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, itemDetails>();

        foreach (itemDetails item in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(item.itemCode, item);
        }
    }

    public void CreateInventoryLists()
    {
        inventoryLists = new List<InventoryItem>[(int)InventoryLocation.count];
        for (int i = 0; i < (int)InventoryLocation.count; i++)
        {
            inventoryLists[i] = new List<InventoryItem>();
        }

        inventoryListCapacityInArray = new int[(int)InventoryLocation.count];
        inventoryListCapacityInArray[(int)InventoryLocation.player]= Settings.playerInitialInventoryCapacity;
    }

    public void AddItem(InventoryLocation inventoryLocation, Item item)
    {
        int itemCode = item.itemCode;
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);
        if (itemPosition != -1)
        {
            AddItemAtPosition(inventoryList, itemCode, itemPosition);
            
        }
        else
        {
            AddItemAtPosition(inventoryList, itemCode);

        }
        DebugAddItemToInventoryList(inventoryList);
        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
    }
    public void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode, int itemPosition)
    {
        InventoryItem inventoryItem = new InventoryItem();

        inventoryItem.itemCode = itemCode;
        inventoryItem.itemQuantity = inventoryList[itemPosition].itemQuantity + 1;
        inventoryList[itemPosition] = inventoryItem;
    }

    public void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode)
    {
        InventoryItem inventoryItem = new InventoryItem();
        inventoryItem.itemCode = itemCode;
        inventoryItem.itemQuantity = 1;
        inventoryList.Add(inventoryItem);

    }

    public void RemoveItemFromInventory(InventoryLocation inventoryLocation, int itemCode)
    {
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];
        int index = FindItemInInventory(inventoryLocation, itemCode);
        RemoveItemAtIndex(inventoryList, index, itemCode);
        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);

    }

    public void RemoveItemAtIndex(List<InventoryItem> inventoryList , int index, int itemcode)
    {
        InventoryItem inventoryItem = new InventoryItem();
        inventoryItem.itemCode = itemcode;
        inventoryItem.itemQuantity = inventoryList[index].itemQuantity; 
        if (inventoryList[index].itemQuantity > 0)
        {
            inventoryItem.itemQuantity = inventoryList[index].itemQuantity - 1;
            inventoryList[index] = inventoryItem;
        }
        else
        {
            inventoryList.RemoveAt(index);
        }
    }
    public int FindItemInInventory(InventoryLocation inventoryLocation, int itemCode)
    {
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];
        for (int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i].itemCode == itemCode)
            {
                return i;
            }
        }

        return -1;
    }

    public void SwapItemInInventory(InventoryLocation inventoryLocation, int fromNumber, int toNumber)
    {
        InventoryItem inventoryItemTmp = inventoryLists[(int)inventoryLocation][fromNumber];

        if (fromNumber < inventoryLists[(int)inventoryLocation].Count && fromNumber != toNumber &&
            toNumber < inventoryLists[(int)inventoryLocation].Count && toNumber >= 0 && fromNumber >= 0)
        {
            inventoryLists[(int)inventoryLocation][fromNumber] = inventoryLists[(int)inventoryLocation][toNumber];
            inventoryLists[(int)inventoryLocation][toNumber] = inventoryItemTmp;
            
            EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
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
    
    public string GetItemTypeDescription(ItemType itemType)
    {
        string itemTypeDescription;
        switch (itemType)
        {
            case ItemType.BreakingTool:
                itemTypeDescription = Settings.BreakingTool;
                break;
            case ItemType.ChoppingTool:
                itemTypeDescription = Settings.ChoppingTool;
                break;
            case ItemType.ReapingTool:
                itemTypeDescription = Settings.ReapingTool;
                break;
            case ItemType.WateringTool:
                itemTypeDescription = Settings.WateringTool;
                break;
            case ItemType.CollectingTool:
                itemTypeDescription = Settings.CollectingTool;
                break;
            default:
                itemTypeDescription = itemType.ToString();
                break;
        }

        return itemTypeDescription;
    }

    public void DebugAddItemToInventoryList(List<InventoryItem> inventoryItems)
    {
        foreach (var inventoryItem in inventoryItems)
        {
            Debug.Log("----------------------------");
            Debug.Log("name item: " + InventoryManager.Instance.GetItemDetail(inventoryItem.itemCode).itemDescription + " ---- quantity : " + inventoryItem.itemQuantity);
        }
    }
}