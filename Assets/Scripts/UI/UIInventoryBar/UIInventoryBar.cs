using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryBar : MonoBehaviour
{
    private Player player;
    private RectTransform rectTransform;
    public bool isInventoryBarBottom = true;
    [SerializeField] private Sprite blank16x16Sprite = null;
    [SerializeField] private UiInventorySlot[] inventorySlot = null;
    [HideInInspector] public GameObject inventoryBarTextBoxObject;

    public GameObject DragItem;
    private void Awake()
    {
        player = GameObject.FindWithTag(Tags.Player).GetComponent<Player>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        EventHandler.InventoryUpdatedEvent += InventoryUpdated;
    }

    private void OnDisable()
    {
        EventHandler.InventoryUpdatedEvent -= InventoryUpdated;
    }

    private void Update()
    {
        SwitchInventoryPositionBar();
    }

    public void SwitchInventoryPositionBar()
    {
        Vector3 playerViewportPosition = player.GetPlayerViewportPosition();
        if (playerViewportPosition.y > 0.3f && isInventoryBarBottom == false)
        {
            rectTransform.pivot = new Vector2(0.5f, 0f);
            rectTransform.anchorMin = new Vector2(0.5f, 0f);
            rectTransform.anchorMax = new Vector2(0.5f, 0f);
            rectTransform.anchoredPosition = new Vector2(0f, 2.5f);
            isInventoryBarBottom = true;
        }
        else if (playerViewportPosition.y <= 0.3f && isInventoryBarBottom == true)
        {
            rectTransform.pivot = new Vector2(0.5f, 1f);
            rectTransform.anchorMin = new Vector2(0.5f, 1f);
            rectTransform.anchorMax = new Vector2(0.5f, 1f);
            rectTransform.anchoredPosition = new Vector2(0f, -2.5f);
            isInventoryBarBottom = false;
        }
    }
    
    private void ClearInventorySlots()
    {
        for (int i = 0; i < inventorySlot.Length; i++)
        {
            inventorySlot[i].inventorySlotImage.sprite = blank16x16Sprite;
            inventorySlot[i].TextMeshProUGUI.text = "";
            inventorySlot[i].itemQuantity = 0;
            inventorySlot[i].itemDetails = null;
        }
    }
    
    public void InventoryUpdated(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList)
    {
        if (inventoryLocation == InventoryLocation.player)
        {
            ClearInventorySlots();

            if (inventorySlot.Length > 0 && inventoryList.Count > 0)
            {
             
                for (int i = 0; i < inventorySlot.Length; i++)
                {
                    if (i < inventoryList.Count)
                    {
                        int itemCode = inventoryList[i].itemCode;
                        Debug.LogError(inventoryList[i].itemCode);
                        itemDetails itemDetails = InventoryManager.Instance.GetItemDetail(itemCode);

                        if (itemDetails != null)
                        {
                            inventorySlot[i].inventorySlotImage.sprite = itemDetails.itemSprite;
                            inventorySlot[i].TextMeshProUGUI.text = inventoryList[i].itemQuantity.ToString();
                            inventorySlot[i].itemDetails = itemDetails;
                            inventorySlot[i].itemQuantity = inventoryList[i].itemQuantity;
                            // SetHighlightInventorySlots(i);
                        }
                    }
                }   
            }
            
        }
    }
}