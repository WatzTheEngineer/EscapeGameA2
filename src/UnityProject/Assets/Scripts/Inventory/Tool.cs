using UnityEngine;

[CreateAssetMenu(menuName = "Items/Tool Item Data")]
public class Tool : ItemData, IUsable, IEquipable
{
    [SerializeField] public int durability = 100;
    public int Durability => durability;

    public void OnUse(InventoryContext context)
    {
        Debug.Log("Use : " + itemName);
        durability--;
        Debug.Log("Durability : " + durability);
    }
    
    public void OnEquip(InventoryContext context)
    {
        Debug.Log("Equip : " + itemName);
    }
    
}