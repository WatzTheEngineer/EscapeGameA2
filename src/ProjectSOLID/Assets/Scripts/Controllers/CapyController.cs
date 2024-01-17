using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouterController : MonoBehaviour
{
    private int speed = 10;
    private bool canMove = false;
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;
    public GameObject screen5;
    public GameObject screen6;
    public GameObject screen7;
    public GameObject screen8;
    public GameObject screen9;
    public GameObject screen10;
    public GameObject screen11;
    public GameObject screen12;
    public GameObject screen13;
    public GameObject screen14;
    public GameObject screen15;
    public GameObject screen16;
    public GameObject screen17;
    public GameObject screen18;
    public GameObject screen19;
    public GameObject screen20;
    public GameObject screen21;
    public GameObject screen22;
    public GameObject screen23;
    public GameObject screen24;
    public GameObject parkFloor;
    private List<GameObject> screens = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
        screens.Add(screen1);
        screens.Add(screen2);
        screens.Add(screen3);
        screens.Add(screen4);
        screens.Add(screen5);
        screens.Add(screen6);
        screens.Add(screen7);
        screens.Add(screen8);
        screens.Add(screen9);
        screens.Add(screen10);
        screens.Add(screen11);
        screens.Add(screen12);
        screens.Add(screen13);
        screens.Add(screen14);
        screens.Add(screen15);
        screens.Add(screen16);
        screens.Add(screen17);
        screens.Add(screen18);
        screens.Add(screen19);
        screens.Add(screen20);
        screens.Add(screen21);
        screens.Add(screen22);
        screens.Add(screen23);
        screens.Add(screen24);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && parkFloor.transform.position.z < 38f) 
        {
            parkFloor.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            foreach(GameObject go in screens)
            {
                go.SetActive(true);
            }
        }
        else
        {
            parkFloor.transform.Translate(-Vector3.forward * Time.deltaTime * speed);
            foreach (GameObject go in screens)
            {
                go.SetActive(false);
            }

        }
        
    }

    public void capy()
    {
        canMove = !canMove;
        
    }
}
