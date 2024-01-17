using UnityEngine;

namespace DefaultNamespace
{
    public class EjectDisquetteTrigger : MonoBehaviour, ITriggerable
    {
        public GameObject diskette;
        InsertDisquetteTrigger script;
        public GameObject exitDoor;
        public GameObject postit;

        private Inventory inventory;
        [SerializeField] private GameObject disquette;
        [SerializeField] private Item[] ActionItems;
        public void Trigger()
        {
            script = diskette.GetComponent<InsertDisquetteTrigger>();
            script.isInserted = false;
            disquette.SetActive(false);
            gameObject.SetActive(false);
            inventory = FindObjectOfType<Inventory>();
            foreach (Item item in ActionItems)
            {
                inventory.AddItem(item);
            }
            exitDoor.SetActive(true);
            postit.SetActive(false);
        }
}
}