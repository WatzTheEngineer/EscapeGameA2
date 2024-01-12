using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool debugMode = false;
    public GameObject pauseMenuUI;
    public GameObject obj;

    void Update()
    {

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
    
}
