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
    public GameObject yellowWire;
    public GameObject blueWire;
    public GameObject redWire;
    public GameObject armedScreen;
    public GameObject door;
    private bool armed = true;


    void Start()
    {
        //timerText = GetComponent<TextMeshPro>();
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        doorController doorScript = door.GetComponent<doorController>();
        while (timeRemaining >= 0)
        {
            if (!(yellowWire.gameObject.activeSelf || blueWire.gameObject.activeSelf || redWire.activeSelf))
            {
                door.gameObject.SetActive(true);
                armed = false;
                armedScreen.SetActive(false);
                doorScript.CloseDoor();


                timerText.text = "xx:xx";
                break;
            }
            else
            {
                timeRemaining -= Time.deltaTime;
                float min = Mathf.FloorToInt(timeRemaining / 60);
                float sec = Mathf.FloorToInt(timeRemaining % 60);
                if (min < 10)
                {
                    if (sec < 10)
                    {
                        display = "0" + min.ToString() + ":0" + sec.ToString();
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
                        display = min.ToString() + ":0" + sec.ToString();
                    }
                    else
                    {
                        display = min.ToString() + ":" + sec.ToString();
                    }
                }

                timerText.text = display;
                yield return null;

            }
        }

        if (armed)
        {
            timerText.text = "BOOM";

            explosion.SetActive(true);

        }
        
    }

    public void penality(float timepenality)
    {
        timeRemaining -= timepenality;
    }
}