using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlugHeadConttroller : MonoBehaviour, ITriggerable
{
    
    private bool headIsPlugged = false;

    public void Trigger()
    {
        headIsPlugged = !headIsPlugged;
    }
    
    public bool GetHeadPlugState()
    {
        return headIsPlugged;
    }   
}


