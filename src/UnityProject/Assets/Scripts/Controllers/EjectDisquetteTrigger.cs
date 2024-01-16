using UnityEngine;

namespace DefaultNamespace
{
    public class EjectDisquetteTrigger : MonoBehaviour, ITriggerable
    {
        public GameObject diskette;
        InsertDisquetteTrigger script;

        private Inventory inventory;
        [SerializeField] private GameObject disquette;
        [SerializeField] private Item ActionItem;
        public void Trigger()
        {
            script = diskette.GetComponent<InsertDisquetteTrigger>();
            script.isInserted = false;
            disquette.SetActive(false);
            gameObject.SetActive(false);
            inventory = FindObjectOfType<Inventory>();
            inventory.AddItem(ActionItem);

        }
}
}