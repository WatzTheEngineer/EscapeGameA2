using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ComputerController : MonoBehaviour
{
    bool paused = false;
    bool isRunning = false;
    public bool isVisible = true;
    public GameObject pauseMenuUI;
    public GameObject computer;
    ComputerController ComputerControllerScript;
    public PlugHeadConttroller plugHeadConttroller;
    


    public void WindowsLaunch()
    {
        plugHeadConttroller = computer.GetComponent<PlugHeadConttroller>();
        

        if (plugHeadConttroller.GetHeadPlugState())
        {
            
            paused = togglePause();
        
            OnDisplay();
        }
        
    }

    void OnDisplay()
    {
        if (paused && !isRunning)
        {
                isRunning = !isRunning;
                isVisible = !isVisible;
                pauseMenuUI.SetActive(true);
                Cursor.visible = isVisible;
                Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
 
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
        ComputerControllerScript = computer.GetComponent<ComputerController>();
        ComputerControllerScript.enabled = false;
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
