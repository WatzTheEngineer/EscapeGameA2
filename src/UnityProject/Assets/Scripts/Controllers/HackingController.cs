using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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
    public float time;
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void launchProgressBar()
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
        StartCoroutine(ProgressBarCoroutine());
        
    }
    IEnumerator ProgressBarCoroutine()
    {
        Debug.Log("zzetrtz");
        Debug.Log(progressBar.Count);
        foreach (GameObject part in progressBar)
        {
            Debug.Log("zzetrtzezazezrfzerfzesrftze");

            part.SetActive(true);
            yield return new WaitForSeconds(time);
            part.SetActive(false);

        }
        part10.SetActive(true);
    }

    
}
