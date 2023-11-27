using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour

{
    public GameObject button;
    public float maxX;
    public float maxZ;
    public GameObject Sphere;
    public Transform SpawnPoint;
    private bool buttonIsOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {

        if (Input.GetMouseButtonUp(0))
        {
            if (buttonIsOn == false)
            {
               
                button.transform.Translate(0,-0.05f,0);
                buttonIsOn = true;
                InvokeRepeating("SpawnSphere", 1f, 2f);
            }
            else
            {
                button.transform.Translate(0, 0.05f, 0);
                buttonIsOn = false;
                CancelInvoke();
            }


        }


    }
    void SpawnSphere()
    {

        Vector3 randomSpawnPos = new Vector3(SpawnPoint.position.x, SpawnPoint.position.y, SpawnPoint.position.z);
        Instantiate(Sphere, randomSpawnPos, Quaternion.identity);
    }
}
