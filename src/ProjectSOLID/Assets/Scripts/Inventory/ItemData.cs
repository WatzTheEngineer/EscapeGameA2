using UnityEngine;

[CreateAssetMenu(menuName = "Items/Item Data")]
public class ItemData : ScriptableObject
{
   [SerializeField] public string itemName ;
   [SerializeField] public int stackMaxCount;
   [SerializeField] public Sprite icon;
}


public interface IConsumable
{
    void OnConsume(InventoryContext context);
}


public interface IUsable
{
    void OnUse(InventoryContext context);
}

public interface IDurable
{
    int Durability { get; }
    
    void OnBreak(InventoryContext context);
    
    void OnRepair(InventoryContext context);
}

public interface IEquipable
{
    void OnEquip(InventoryContext context);
}
