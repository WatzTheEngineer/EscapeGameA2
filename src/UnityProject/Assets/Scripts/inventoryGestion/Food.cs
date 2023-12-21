using UnityEngine;

[CreateAssetMenu(menuName = "Items/Food Item Data")]
public class Food : ItemData, IConsumable
{
    [SerializeField] public int feedingFactor = 1;
    
    public void OnConsume(InventoryContext context)
    {
        Debug.Log("Feed : " + feedingFactor);
    }
}