
using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Item : MonoBehaviour
{
    [SerializeField] public  int itemCode;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if (itemCode != 0)
        {
            Init(itemCode);
        }
    }

    public void Init(int itemCode)
    {
        if (itemCode != 0)
        {
            itemDetails itemDetails;

            itemDetails = InventoryManager.Instance.GetItemDetail(itemCode);
            spriteRenderer.sprite = itemDetails.itemSprite;
            if (itemDetails.itemType == ItemType.ReapableScenary)
            {
                gameObject.AddComponent<ItemNudge>();
            }
        }
    }
}
