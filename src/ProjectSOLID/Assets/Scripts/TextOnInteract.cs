using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class TextOnInterract : MonoBehaviour
{
    [SerializeField] private string textToSend;
    [SerializeField] private GameObject UI;

    public void Send()
    {
        UI.GetComponent<MitnickUIController>().ShowText(textToSend);
    }
}
