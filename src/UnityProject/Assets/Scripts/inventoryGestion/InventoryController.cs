using System;
using UnityEngine;

namespace inventoryGestion
{
    public class InventoryController : MonoBehaviour
    {
        public GameObject panel;
        public bool isVisible = false;
        
        private void Update()
        {
            panel.SetActive(isVisible);
            
            ifICapPressedOpenInventory();
            
            
        }
        
        void ifICapPressedOpenInventory()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                isVisible = !isVisible;
                panel.SetActive(isVisible);

                Cursor.visible = isVisible;
                Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }
        
    }
}