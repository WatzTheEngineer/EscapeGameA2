using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class lockPickingController : MonoBehaviour
    
{
    public Slider latch1;
    public Slider latch2;
    public Slider latch3;
    public Slider latch4;
    public Slider latch5;
    public bool isVisible = false;
    public bool isPaused = false;
    public GameObject monObj;
    public GameObject ui;
    FPSController script;
    public GameObject door;
    private InteractiveController doorAnimationScript;

    // Start is called before the first frame update
   
    public void launchLockPicking()
    {
        gameObject.SetActive(true);
        TogglePauseMenu();
        togglePause();
        isPaused = !isPaused;
        script = monObj.GetComponent<FPSController>();
        script.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (IsMouseOverSlider(latch1) && Input.GetMouseButton(0))
        {
            
            latch2.value = latch1.value;

        }
        
        else if(IsMouseOverSlider(latch2) && Input.GetMouseButton(0))
        {
            

        }

        else if(IsMouseOverSlider(latch3) && Input.GetMouseButton(0))
        {
            latch2.value = 1-latch3.value;
        }
        else if(IsMouseOverSlider(latch4) && Input.GetMouseButton(0))
        {
            latch1.value = 1-latch4.value;
        }
        else if(IsMouseOverSlider(latch5) && Input.GetMouseButton(0))
        {
            latch1.value = latch5.value;
            latch4.value = 1-latch5.value;
        }

        if (latch1.value.Equals(1) && latch2.value.Equals(1) && latch3.value.Equals(1) && latch4.value.Equals(1) && latch5.value.Equals(1))
        {
            
            doorAnimationScript = door.GetComponent<InteractiveController>();
            doorAnimationScript.PlayAnimation();
            returnButton();
        }

    }
    private bool IsMouseOverSlider(Slider slider)
    {
        Vector2 mousePosition = Input.mousePosition;
        RectTransform sliderRect = slider.GetComponent<RectTransform>();

        return RectTransformUtility.RectangleContainsScreenPoint(sliderRect, mousePosition);
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
    public void returnButton()
    {
        togglePause();
        isVisible = !isVisible;
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        script.enabled = true;
        isPaused = !isPaused;
        ui.gameObject.SetActive(false);
        latch1.value = 0;
        latch2.value = 0;
        latch3.value = 0;
        latch4.value = 0;
        latch5.value = 0;
    }
    public void TogglePauseMenu()
    {
        isVisible = !isVisible;
        
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
