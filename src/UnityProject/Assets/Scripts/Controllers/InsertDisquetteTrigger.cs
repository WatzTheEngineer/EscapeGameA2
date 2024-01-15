using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class InsertDisquetteTrigger: MonoBehaviour, ITriggerable
    {
        private bool isInserted = false;
        private Inventory inventory;
        [SerializeField] private Item ActionItem;
        public void Start()
        {
            isInserted = false;
            gameObject.SetActive(false);
        }

        public void Trigger()
        {

                isInserted = !isInserted;
                gameObject.SetActive(true);
                gameObject.GetComponent<Animator>().Play("OPEN",0,0.0f);
                inventory = FindObjectOfType<Inventory>();
                inventory.PickItem(ActionItem);

        }
    
        public bool GetHeadPlugState()
        {
            return isInserted;
        }   
    }
}