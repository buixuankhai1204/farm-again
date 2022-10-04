
using UnityEngine;

[System.Serializable]
public class itemDetails
{
    public int itemCode;
    public ItemType itemType;
    public string itemDescription;
    public Sprite itemSprite;
    public string itemLongDescription;
    public short itemUseGridRadius;
    public float itemUseRadius;
    public bool isStartItem;
    public bool canBePickup;
    public bool canBeDropped;
    public bool canBeEaten;
    public bool canBeCarried;
}
