using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouterController : MonoBehaviour
{
    private int speed = 10;
    private bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && transform.position.z < 38f) 
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        
    }

    public void capy()
    {
        canMove = true;
    }
}
