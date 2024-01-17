using UnityEngine;

public class endMitnickChaseTrigger : MonoBehaviour, ITriggerable
{
    public bool isVisible;

    [SerializeField] private GameObject endUi;
    [SerializeField] private GameObject MitnickUI;

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Trigger()
    {
        MitnickUI.SetActive(false);
        isVisible = !isVisible;
        Debug.Log("Trigger");
        endUi.SetActive(true);
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        togglePause();
    }

    public bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return false;
        }

        Time.timeScale = 0f;
        return true;
    }
}