
using System;

using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class IventorySlot : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler,IDropHandler
{
    private int index; 
    private Vector3 initiaImageLocallPosition;
    
    
    [SerializeField] private TextMeshProUGUI ItemCountText;
    [SerializeField] private Image itemImage;
    
    private InventoryDisplay inventoryDisplay;
    private Button button;
    public void Initialyze(InventoryDisplay _inventoryDisplay, int _index)
    {
        button = GetComponent<Button>();
        
        button.onClick.AddListener(onClick);
        index = _index;
        inventoryDisplay = _inventoryDisplay;
    }


    public void UpdateDisplay(Item _item)
    {
        if (!_item.Empty)
        {
            ItemCountText.text = _item.Count.ToString();
            itemImage.sprite = _item.Data.icon;
            itemImage.color = Color.white;
            return;
        }
        
        ItemCountText.text = "";
        itemImage.sprite = null;
        itemImage.color = new Color(0,0,0,0);
    }
    
    private void onClick()
    {
        inventoryDisplay.clickSlot(index);
    }
    
    
    #region Drag and drop

    public void OnBeginDrag(PointerEventData eventData)
    {
        inventoryDisplay.dragSlot(index);
        
        initiaImageLocallPosition = itemImage.transform.localPosition;
        itemImage.transform.SetParent(inventoryDisplay.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemImage.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemImage.transform.SetParent(transform);
        itemImage.transform.localPosition = initiaImageLocallPosition;
    }
    
    public void OnDrop(PointerEventData eventData)
{
        inventoryDisplay.dropOnSlot(index);
    }
    
    #endregion

    
}