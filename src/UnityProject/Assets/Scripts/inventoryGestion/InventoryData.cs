public class InventoryData
{
    public InventoryData(int slotCount)
    {
        items = new Item[slotCount];
    } 
    
    public Item[] items { private set; get; }

    public bool SlotAvailable(Item itemToAdd)
    {
        foreach (var item in items)
        {
            if (item.avaibleFor((itemToAdd))) return true;
        }

        return false;
    }

    public void AddItem(ref Item itemToAdd)
    {
        if (itemToAdd.Empty) return;
        
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].avaibleFor(itemToAdd))
            {
                items[i].merge(ref itemToAdd);
            }
        }
    }

    public Item Pick(int slotID)
    { 
        if (slotID > items.Length) throw new System.Exception($"Id {slotID} out of inventory");

        Item item = items[slotID];
        items[slotID] = new Item();

        return item;
    }
    
    
    public void Swap(int slotId1, int slotId2)
    {
        if (slotId1 > items.Length || slotId2 > items.Length) throw new System.Exception($"Id {slotId1} or {slotId2} out of inventory");

        Item temp = items[slotId1];
        items[slotId1] = items[slotId2];
        items[slotId2] = temp;
    }
}