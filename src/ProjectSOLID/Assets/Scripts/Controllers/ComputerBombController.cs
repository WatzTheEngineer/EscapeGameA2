using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ComputerBombController : MonoBehaviour
{
    bool paused = false;
    bool isRunning = false;
    public bool isVisible = false;
    public bool haveInternet = false;
    public GameObject pauseMenuUI;
    public GameObject computer;
    ComputerBombController ComputerControllerScript;
    FPSController script;
    public GameObject player;
    public bool forceOn;



    [SerializeField] public GameObject screen;

    public void Update()
    {
        screen.SetActive(true);
    }

 


    public void WindowsLaunch()
    {
        //Cursor.visible = isVisible;
        //Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        OnDisplay();
        script = player.GetComponent<FPSController>();
        script.enabled = false;

    }

    void OnDisplay()
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
    public void WindowsQuit()
    {
        pauseMenuUI.SetActive(false);
        isRunning = !isRunning;
        isVisible = !isVisible;
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        ComputerControllerScript = computer.GetComponent<ComputerBombController>();
        ComputerControllerScript.enabled = false;
        script.enabled = true;
    }
    
}
