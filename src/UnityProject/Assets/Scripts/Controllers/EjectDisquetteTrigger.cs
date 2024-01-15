using UnityEngine;

namespace DefaultNamespace
{
    public class EjectDisquetteTrigger : MonoBehaviour, ITriggerable
    {
        private Inventory inventory;
        [SerializeField] private GameObject disquette;
        [SerializeField] private Item ActionItem;
        public void Trigger()
        {
            disquette.SetActive(false);
            gameObject.SetActive(false);
            inventory = FindObjectOfType<Inventory>();
            inventory.AddItem(ActionItem);

        }
}
}