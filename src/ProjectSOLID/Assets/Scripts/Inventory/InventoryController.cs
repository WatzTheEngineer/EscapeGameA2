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
        FPSController script;
        public GameObject monObj;

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
                script = monObj.GetComponent<FPSController>();
                
                isVisible = !isVisible;
                
                panel.SetActive(isVisible);

                Cursor.visible = isVisible;
                Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;

                if (isVisible)
                {
                    script.enabled = false;
                }
                else
                {
                    script.enabled = true;
                }
            }
        }
        
    }
}