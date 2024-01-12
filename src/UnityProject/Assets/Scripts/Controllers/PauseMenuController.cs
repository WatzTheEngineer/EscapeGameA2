using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public bool isVisible = false;
    public bool isPaused = false;
    public GameObject monObj;
    public static bool isOn;

    FPSController script;
    private void Start()
    {
        isOn = false;
        
        
    }

    [SerializeField] private GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            if (!isPaused)
            {
                TogglePauseMenu();
                togglePause();
                script = monObj.GetComponent<FPSController>();
                script.enabled = false;
                isPaused = !isPaused;
            }
            

        }
    }

    public void TogglePauseMenu()
    {
        isVisible = !isVisible;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        isOn = pauseMenu.activeSelf;
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }
    public void returnButton()
    {
        togglePause();
        isVisible = !isVisible;
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        script.enabled = true;
        isPaused = !isPaused;
    }

    public void quitButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    bool togglePause()
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
