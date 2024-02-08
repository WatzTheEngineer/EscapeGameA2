using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{

    [SerializeField] private InventoryContextMenu contextMenu;
    private IventorySlot[] slots;
    private int dragedSlotIndex;
    private Inventory inventory;
    
    public int initialyze(Inventory _inventory)
    {
        slots = GetComponentsInChildren<IventorySlot>();
        inventory = _inventory;
        contextMenu.initialyze(inventory);
        
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Initialyze(this, i);
            
        }
        return slots.Length; 
    }

    public void updateDisplay(Item[] _items)
    {
      for (int i = 0; i < slots.Length; i++)
      {
          slots[i].UpdateDisplay(_items[i]);
      }  
    }

    #region Inputs

    public void clickSlot(int index)
    {
        contextMenu.Select(index, slots[index]);
    }
    
    public void dragSlot(int index)
    {
        dragedSlotIndex = index;
    }

    public void dropOnSlot(int index)
    {
        
        inventory.SwapSlot(dragedSlotIndex, index);
        /*contextMenu.Select(index, slots[index]);*/
        
    }

    #endregion
    
}