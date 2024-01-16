using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endMitnickChaseTrigger : MonoBehaviour, ITriggerable
{
    [SerializeField] GameObject endUi;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    
    public void Trigger()
    {
        Debug.Log("Trigger");
        endUi.SetActive(true);
        
    }
    
}
