using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        if (dist > 1.9f) 
        {
            hasPlayer = true;      
        }
        else
        {
            hasPlayer = false;
        }
        
        if (hasPlayer && Input.GetKey(KeyCode.E)) 
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }

        if (beingCarried)
        {
            if (touched) 
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            if(Input.GetMouseButtonDown(0)) 
            {
                GetComponent<Rigidbody>().isKinematic= false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            }

            else if(Input.GetMouseButtonDown(1))
            {
                GetComponent <Rigidbody>().isKinematic= false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }

    private void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
    
}
