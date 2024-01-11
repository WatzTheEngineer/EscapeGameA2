using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerController : MonoBehaviour
{
    bool paused = false;
    bool isRunning = false;
    public bool isVisible = true;
    public bool debugMode = false;
    public GameObject pauseMenuUI;
    public GameObject obj;
    ComputerController script;

    

    public void WindowsLaunch()
    {
        paused = togglePause();
        
        OnDisplay();
    }

    void OnDisplay()
    {
        if (paused)
        {
            if (!isRunning)
            {
                isRunning = !isRunning;
                isVisible = !isVisible;
                pauseMenuUI.SetActive(true);
                Cursor.visible = isVisible;
                Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }
    }
    public void WindowsQuit()
    {
        Debug.Log("Assert");
        pauseMenuUI.SetActive(false);
        isRunning = !isRunning;
        isVisible = !isVisible;
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        paused = togglePause();
        script = obj.GetComponent<ComputerController>();
        script.enabled = false;
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
