using UnityEngine;

namespace inventoryGestion
{
    [CreateAssetMenu(menuName = "Items/Diskette Item Data")]
    public class diskette: ItemData
    {
        [SerializeField] public string disketteName;
        
    }
}