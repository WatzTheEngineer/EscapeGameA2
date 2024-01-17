using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class InsertDisquetteTrigger: MonoBehaviour, ITriggerable
    {
        public bool isInserted = false;
        public GameObject postit;
        private Inventory inventory;
        [SerializeField] private Item[] ActionItems;
        
        public void Start()
        {
            isInserted = false;
            gameObject.SetActive(false);
        }

        public void Trigger()
        {

                isInserted = !isInserted;
            Debug.Log("Trigger" + isInserted);
                gameObject.SetActive(true);
                postit.SetActive(true);
                gameObject.GetComponent<Animator>().Play("OPEN",0,0.0f);
                inventory = FindObjectOfType<Inventory>();
            foreach (Item item in ActionItems)
            {
                inventory.PickItem(item);
            }
                

        }
    
        public bool GetHeadPlugState()
        {
            return isInserted;
        }   
    }
}