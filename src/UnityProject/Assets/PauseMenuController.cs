using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public bool isVisible = false; 
    private void Start()
    {
        PauseMenu.isOn = false;
    }

    [SerializeField] private GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        isVisible = !isVisible;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.isOn = pauseMenu.activeSelf;
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
