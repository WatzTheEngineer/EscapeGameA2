﻿using UnityEngine;

namespace inventoryGestion
{
    [CreateAssetMenu(menuName = "Items/Diskette Item Data")]
    public class diskette: ItemData, IUsable
    {
        [SerializeField] public string disketteName;
    
        public void OnUse(InventoryContext context)
        {
            Debug.Log("Use : " + disketteName);
        }
    }
}