using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endMitnickChaseTrigger : MonoBehaviour, ITriggerable
{
    public bool isVisible = false;

    [SerializeField] GameObject endUi;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Trigger()
    {
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
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }

    }
}
