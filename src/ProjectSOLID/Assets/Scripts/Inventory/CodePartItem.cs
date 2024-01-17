using UnityEngine;

namespace inventoryGestion
{
    [CreateAssetMenu(menuName = "Items/Sheet code Item Data")]
    public class CodePartItem : ItemData
    {
        [SerializeField] public string codePartName;
    }
    
}