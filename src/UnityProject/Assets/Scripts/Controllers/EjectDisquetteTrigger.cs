using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class EjectDisquetteTrigger : MonoBehaviour, ITriggerable
    {
        private const string endMessage = "J'ai fini mon travail ici. Je peux retourner à mon camion.";
        public GameObject diskette;
        public GameObject exitDoor;
        public GameObject postit;
        [SerializeField] private GameObject disquette;
        [SerializeField] private Item[] ActionItems;
        [SerializeField] private GameObject basePanel;
        [SerializeField] private GameObject UI;

        private Inventory inventory;
        private InsertDisquetteTrigger script;

        public void Trigger()
        {
            script = diskette.GetComponent<InsertDisquetteTrigger>();
            script.isInserted = false;
            disquette.SetActive(false);
            gameObject.SetActive(false);
            inventory = FindObjectOfType<Inventory>();
            foreach (var item in ActionItems) inventory.AddItem(item);
            exitDoor.SetActive(true);
            postit.SetActive(false);

            var loadingPanel = Instantiate(basePanel, UI.transform, true);
            loadingPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = endMessage;
        }
    }
}