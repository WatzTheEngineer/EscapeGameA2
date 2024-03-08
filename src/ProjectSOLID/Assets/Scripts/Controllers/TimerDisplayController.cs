using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class TimerDisplayController : MonoBehaviour
{
    public TextMeshPro timerText;
    public float timeRemaining = 120f;
    private string display;
    public GameObject explosion;

    void Start()
    {
        //timerText = GetComponent<TextMeshPro>();
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            float min = Mathf.FloorToInt(timeRemaining / 60);
            float sec = Mathf.FloorToInt(timeRemaining % 60);
            if (min < 10)
            {
                if (sec < 10)
                {
                    display = "0"+min.ToString() + ":0" + sec.ToString();
                }
                else
                {
                    display = "0" + min.ToString() + ":" + sec.ToString();
                }
                
            }
            else
            {
                if (sec < 10)
                {
                    display =min.ToString() + ":0" + sec.ToString();
                }
                else
                {
                    display = min.ToString() + ":" + sec.ToString();
                }
            }
            
            timerText.text = display;
            yield return null;

        }

        timerText.text = "BOOM";

        explosion.SetActive(true);
    }
}