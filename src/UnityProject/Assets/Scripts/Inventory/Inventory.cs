using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] private InventoryDisplay display;
    private InventoryData data;

    private InventoryContext context;
    
    private void Awake()
    {
        int slotCount = display.initialyze(this);

        data = new InventoryData(slotCount);
        display.updateDisplay(data.items);
    }

    public Item AddItem(Item item)
    {
        if (!data.SlotAvailable(item)) return item;

        data.AddItem(ref item);
        
        display.updateDisplay(data.items);
        return item;
    }

    public Item PickItem(Item item)
    {
        Item result = data.Pick(item);
        
        display.updateDisplay(data.items);

        return result;
    }
    
    public void SwapSlot(int slotId1, int slotId2)
    {
        data.Swap(slotId1, slotId2);
        
        display.updateDisplay(data.items);
    }
    
    public Item[] Data => data.items;
    
    public InventoryContext Context => context;

}







