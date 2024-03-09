using System.Collections;
using TMPro;
using UnityEngine;
public class TankDisplayController : MonoBehaviour
{
    public TextMeshPro timerText;
    private float time = 0f;
    private string display;
    private bool isAcitve = false;

    void Start()
    {
        
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (!isAcitve)
        {
            time += Time.deltaTime;
            
            float sec = Mathf.FloorToInt(time % 60);
            if (sec == 0 || sec == 30)
            {
                display = "0-----";
            }
            else if (sec == 5)
            {
                display = "-1----";
            }
            else if(sec == 10 )
            {
                display = "--0---";
            }
            else if(sec == 15 )
            {
                display = "---0--";
            }
            else if(sec == 20)
            {
                display = "----1-";
            }
            else if(sec == 25)
            {
                display = "-----1";
                time = -5;
                
            }

            timerText.text = display;
            yield return null;

        }
        timerText.text = "------";

    }
    public void switchMode()
    {
        isAcitve = true;
    }
}