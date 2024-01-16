using DefaultNamespace;
using inventoryGestion;
using UnityEngine;
using Utils;

    public class InventoryInteractiveController: MonoBehaviour,IRaycastable
    {
        private GameObject _gameObject;
        [SerializeField] private Item _item;
        private bool isOpen = false;

        [SerializeField] private GameObject[] triggeredObjects;
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = FindObjectOfType<Inventory>();
        }
        
        public void PlayAnimation()
        {
            if (!isOpen)
            {
                gameObject.SetActive(false);
                isOpen = true;
                _inventory.AddItem(_item);
                foreach (var obj in triggeredObjects)
                {
                    obj.GetComponent<ITriggerable>().Trigger();
                }
            }
        }
    }
