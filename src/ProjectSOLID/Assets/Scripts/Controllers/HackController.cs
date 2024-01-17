using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HackController : MonoBehaviour
{
    public float time;
    public GameObject sucess;
    public GameObject hackMenu;
    public GameObject hackButton;
    

    public void HackSucess()
    {
        StartCoroutine(SucessCoroutine());
    }

    IEnumerator SucessCoroutine()
    {
        
        yield return new WaitForSeconds(time);

        sucess.SetActive(true);
        yield return new WaitForSeconds(3f);
        hackMenu.SetActive(false);
        hackButton.SetActive(false);
    }
}
