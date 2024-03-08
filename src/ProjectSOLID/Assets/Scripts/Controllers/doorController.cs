using System;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public bool opening = false;
    public Transform door;


    void Update()
    {
        if (opening)
        {
  
            OpenDoor();
        }
        
        

        
        
    }

    private void OnTriggerEnter(Collider obj)
    {
        if(obj.transform.name == "Player"){opening = true;}

        if (obj.transform.name == "DoorCloseTrigger"){opening = false;}
    }

    void OpenDoor()
    {
        float movement = 0.7f * Time.deltaTime;

        if (door.position.y - 5.5 > 0 ) {
            door.position = new Vector3(door.position.x, door.position.y - movement, door.position.z);
        }
    
            
        
        

    }
}
