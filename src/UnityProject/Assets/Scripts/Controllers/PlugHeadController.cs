using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlugHeadConttroller : MonoBehaviour, ITriggerable
{
    public GameObject screen;
    private bool headIsPlugged = false;

    public void Trigger()
    {
        headIsPlugged = !headIsPlugged;
        screen.gameObject.SetActive(true);
    }
    
    public bool GetHeadPlugState()
    {
        return headIsPlugged;
    }   
}


