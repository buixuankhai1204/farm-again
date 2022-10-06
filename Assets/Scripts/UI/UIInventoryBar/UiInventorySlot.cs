using System;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Camera mainCamera;
    private Transform parentItem;
    private GameObject dragItem;
    public GameObject itemPrefab;
    public Image inventorySlotHighlight;
    public Image inventorySlotImage;
    public TextMeshProUGUI TextMeshProUGUI;
    
    [HideInInspector] public itemDetails itemDetails;
     public UIInventoryBar inventoryBar;
    [HideInInspector] public int itemQuantity;
    public int slotNumber;
    public GameObject inventoryObjectPrefab;
    public Canvas parentCanvas;

    private void Awake()
    {
        mainCamera = Camera.main;
        parentItem = GameObject.FindWithTag(Tags.ParentItemTransform).transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemDetails != null)
        {
            Player.Instance.DisablePlayerInput();
            dragItem = Instantiate(inventoryBar.DragItem, inventoryBar.transform);
            Image dragItemImage = dragItem.GetComponentInChildren<Image>();
            dragItemImage.sprite = inventorySlotImage.sprite;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragItem != null)
        {
            dragItem.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10 );
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragItem != null)
        {
            Destroy(dragItem);

            if (eventData.pointerCurrentRaycast.gameObject != null &&
                eventData.pointerCurrentRaycast.gameObject.GetComponent<UiInventorySlot>() != null)
            {
                int toSlotNumber = eventData.pointerCurrentRaycast.gameObject.GetComponent<UiInventorySlot>().slotNumber;
                Debug.Log(toSlotNumber);
                InventoryManager.Instance.SwapItemInInventory(InventoryLocation.player, slotNumber, toSlotNumber);
            }
            else
            {
                if (itemDetails.canBeDropped)
                {
                    DragSelectItemAtPosition(Input.mousePosition);
                }
            }
            
            Player.Instance.EnablePlayerInput();
        }

    }

    public void DragSelectItemAtPosition(Vector3 worldPosition)
    {
        if (itemDetails != null)
        {
            Vector3 worldPositionSpawn =
                mainCamera.ScreenToWorldPoint(new Vector3(worldPosition.x, worldPosition.y, 10));

            GameObject itemGameOject = Instantiate(itemPrefab, worldPositionSpawn, Quaternion.identity, parentItem);
            Item item = itemGameOject.GetComponent<Item>();
            item.itemCode = itemDetails.itemCode;
            InventoryManager.Instance.RemoveItemFromInventory(InventoryLocation.player, item.itemCode);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        inventoryBar.inventoryBarTextBoxObject =
            Instantiate(inventoryObjectPrefab, transform.position, quaternion.identity);
        inventoryBar.inventoryBarTextBoxObject.transform.SetParent(parentCanvas.transform);

        UiInventoryTextBox inventoryTextBox = inventoryBar.inventoryBarTextBoxObject.GetComponent<UiInventoryTextBox>();
        string itemTypeDeScription = InventoryManager.Instance.GetItemTypeDescription(itemDetails.itemType);

        inventoryTextBox.SetTextBox(itemDetails.itemDescription, itemTypeDeScription, "", itemDetails.itemLongDescription, "", "");
        if (inventoryBar.isInventoryBarBottom)
        {
            inventoryBar.inventoryBarTextBoxObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0f);
            inventoryBar.inventoryBarTextBoxObject.transform.position = new Vector3(transform.position.x, transform.position.y + 50, transform.position.z);
        }
        else
        {
            inventoryBar.inventoryBarTextBoxObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
            inventoryBar.inventoryBarTextBoxObject.transform.position = new Vector3(transform.position.x,
                transform.position.y - 50, transform.position.z);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DestroyInventoryTextBox();
    }

    public void DestroyInventoryTextBox()
    {
        if (inventoryBar.inventoryBarTextBoxObject != null)
        {
            Destroy(inventoryBar.inventoryBarTextBoxObject);
        }
    }
}
