using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool paused = false;
    bool isRunning = false;
    public bool isVisible = false;
    public bool debugMode = false;
    public GameObject pauseMenuUI;
    public GameObject obj;
    ComputerController script;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            paused = togglePause();
            OnDisplay();
        }

        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            debugMode = !debugMode;
            if (debugMode)
            {
                Debug.Log("DEBUG MODE ON\n| + : Increase TickRate\n| - : Decrease TickRate");
            }
            else
            {
                Debug.Log("DEBUG MODE OFF");
            }
        }
        if (debugMode)
        {
            
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                Time.timeScale += 0.25f;
                Debug.Log("TICK : " + Time.timeScale);

            }
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                Time.timeScale -= 0.25f;
                Debug.Log("TICK : " + Time.timeScale);
            }
       

        }
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
        Debug.Log("Assert2");
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
