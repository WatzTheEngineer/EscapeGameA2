using System;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public bool mode = false;
    public Transform doorLeft;
    public Transform doorRight;
    public GameObject trigger;


    void Update()
    {
        if (mode)
        {

            Up();
        }
        
        

        
        
    }

 

    public void Up()
    {
        mode = true;
        float movement = 0.7f * Time.deltaTime;

        if (doorLeft.position.x > -52.25)
        {
            doorLeft.position = new Vector3(doorLeft.position.x - movement, doorLeft.position.y, doorLeft.position.z);
            doorRight.position = new Vector3(doorRight.position.x + movement, doorRight.position.y, doorRight.position.z);

        }
       

    }
}
