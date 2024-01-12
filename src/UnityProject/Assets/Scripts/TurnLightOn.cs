using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TurnLightOn : MonoBehaviour, ITriggerable
{
    public void Trigger()
    {
        gameObject.SetActive(true);
    }
}
