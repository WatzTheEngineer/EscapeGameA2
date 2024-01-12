using UnityEngine;

[CreateAssetMenu(menuName = "Items/Letter Item Data")]
public class Letter : ItemData, IUsable
{
    [SerializeField] public string letterContent;
    
    public void OnUse(InventoryContext context)
    {
        Debug.Log("Use : " + letterContent);
    }
}