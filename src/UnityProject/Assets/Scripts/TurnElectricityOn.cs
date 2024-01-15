using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TurnElectricitytOn : MonoBehaviour, ITriggerable
{
    private bool isOn = false;
    
    public void Trigger()
    {
        gameObject.SetActive(true);
        isOn = true;
    }
    
    public bool GetElectricityState()
        {
            return isOn;
        }
        
}
