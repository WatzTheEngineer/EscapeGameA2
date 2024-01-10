using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool paused = false;
    bool isRunning = false;
    public bool isVisible = false;
    public GameObject pauseMenuUI;

    
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            paused = togglePause();
            OnDisplay();
        }
    }
    void OnDisplay()
    {
        if (paused)
        {
            if (!isRunning)
            {
                isRunning = true;
                isVisible = !isVisible;
                pauseMenuUI.SetActive(true);
                Cursor.visible = isVisible;
                Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }
    }
    public void WindowsQuit()
    {
        pauseMenuUI.SetActive(false);
        isRunning = !isRunning;
        isVisible = !isVisible;
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        paused = togglePause();
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
