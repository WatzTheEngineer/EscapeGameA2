using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.O))
        {
            isVisible = !isVisible;
            panel.SetActive(isVisible);

            Cursor.visible = isVisible;
            Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}

