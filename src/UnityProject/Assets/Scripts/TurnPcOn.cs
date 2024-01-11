using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TurnPcOn : MonoBehaviour, ITriggerable
{

    public void Trigger()
    {
        Debug.Log("Ordinateur allumée");
    }
}


