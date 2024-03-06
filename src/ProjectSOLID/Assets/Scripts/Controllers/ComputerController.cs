using System;
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
    public bool haveInternet = false;
    public GameObject pauseMenuUI;
    public GameObject computer;
    ComputerController ComputerControllerScript;
    public GameObject wire;
    public GameObject alimentation;
    public bool pcCouldBeTurnedOn = false;
    FPSController script;
    public GameObject player;
    public bool forceOn;


    [SerializeField] public GameObject screen;

    public void Update()
    {
        
        if((alimentationGetElectricity() && wireIsPlugged()) || forceOn)
        {
            pcCouldBeTurnedOn = true;
            screen.SetActive(true);
        }
        else
        {
            pcCouldBeTurnedOn = false;
        }
    }

    private bool wireIsPlugged()
    {
        return wire.GetComponent<PlugHeadConttroller>().GetHeadPlugState();
    }

    private bool alimentationGetElectricity()
    {
        return alimentation.GetComponent<TurnElectricityOn>().GetElectricityState();
    }

    public void WindowsLaunch()
    {
        
        if (pcCouldBeTurnedOn)
        {
            
            
        
            OnDisplay();
            script = player.GetComponent<FPSController>();
            script.enabled = false;
        }
        
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
        ComputerControllerScript = computer.GetComponent<ComputerController>();
        ComputerControllerScript.enabled = false;
        script.enabled = true;
    }

    

    public void swirchInternet()
    {
        haveInternet = true;
    }
    
}