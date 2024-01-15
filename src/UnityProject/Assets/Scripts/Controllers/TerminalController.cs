using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TerminalController : MonoBehaviour
{
    public TMP_InputField inputFieldTMP;
    public GameObject terminalUI;
    public GameObject mitnickOSUI;
    

    public void VerifierSaisie()
    {
        string saisie = inputFieldTMP.text;

        
        if (saisie == "startMitnickOS")
        {
            terminalUI.SetActive(false);
            mitnickOSUI.SetActive(true);
            inputFieldTMP.text = "";
        }
        
    }
}
