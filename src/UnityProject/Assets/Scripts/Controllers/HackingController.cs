using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HackingController : MonoBehaviour
{
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;
    public GameObject part4;
    public GameObject part5;
    public GameObject part6;
    public GameObject part7;
    public GameObject part8;
    public GameObject part9;
    public GameObject part10;
    public GameObject sucess;
    private float time;
    public GameObject hackMenu;
    public GameObject hackdisketteMenu;

    public float timeInterval;

    private List<GameObject> progressBar;
    // Start is called before the first frame update
    void Start()
    {
        progressBar = new List<GameObject>
        {
            part1,
            part2,
            part3,
            part4,
            part5,
            part6,
            part7,
            part8,
            part9,
            part10
        };

        StartCoroutine(LaucnhHacking());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LaucnhHacking()
    {
        progressBar = new List<GameObject>
        {
            part1,
            part2,
            part3,
            part4,
            part5,
            part6,
            part7,
            part8,
            part9,
            part10
        };
        Time.timeScale = 025f;
        foreach (GameObject part in progressBar)
        {
            
            part.SetActive(true);
            yield return new WaitForSeconds(time);
            part.SetActive(false); 
        }
        Time.timeScale = 1f;
        part10.SetActive(true);
        sucess.SetActive(true);
        
        hackdisketteMenu.SetActive(true);


    }

    

    }

    

   

 
