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
            display = min.ToString() + ":" + sec.ToString();
            timerText.text = display;
            yield return null;

        }

        timerText.text = "BOOM";

        explosion.SetActive(true);
    }
}