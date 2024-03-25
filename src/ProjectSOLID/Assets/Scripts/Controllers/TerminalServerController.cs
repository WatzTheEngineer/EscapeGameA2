using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Device;

public class TerminalServeurController : MonoBehaviour
{
    public TMP_InputField inputFieldTMP;
    public GameObject greenBombLight;
    public GameObject redBombLight;
    private bool isGood;


    public void Update()
    {
        if (isGood)
        {
            inputFieldTMP.text = "CODE BON";
        }
    }




    public void VerifierSaisie()
    {
        string saisie = inputFieldTMP.text;
       

        
        if (saisie == "101011111")
        {
            greenBombLight.SetActive(false);
            redBombLight.SetActive(true);

            isGood = true;
        }
        
    }
}
