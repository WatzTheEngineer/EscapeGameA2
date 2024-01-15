using System;
using UnityEngine;

namespace inventoryGestion
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private Item[] startItems;
        public GameObject panel;
        public bool isVisible = false;
        private Inventory inventory;

        private void Start()
        {
            inventory = FindObjectOfType<Inventory>();
            foreach (Item item in startItems)
            {
                inventory.AddItem(item);
            }
        }

        private void Update()
        {
            panel.SetActive(isVisible);
            
            ifICapPressedOpenInventory();
            
        }
        
        void ifICapPressedOpenInventory()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                isVisible = !isVisible;
                panel.SetActive(isVisible);

                Cursor.visible = isVisible;
                Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }
        
    }
}