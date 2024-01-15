using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlugHeadConttroller : MonoBehaviour, ITriggerable
{
    private bool isPlugged = false;

    public void Trigger()
    {
        isPlugged = !isPlugged;
    }
    
    public bool GetHeadPlugState()
    {
        return isPlugged;
    }   
}


