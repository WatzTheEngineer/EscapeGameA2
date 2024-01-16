using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TerminalController : MonoBehaviour
{
    public TMP_InputField inputFieldTMP;
    public GameObject terminalUI;
    public GameObject mitnickOSUI;
    public GameObject diskette;
    InsertDisquetteTrigger script;


    public void VerifierSaisie()
    {
        script = diskette.GetComponent<InsertDisquetteTrigger>();
        string saisie = inputFieldTMP.text;
        Debug.Log(script.isInserted);

        
        if (saisie == "startMitnickOS" && script.isInserted)
        {
            terminalUI.SetActive(false);
            mitnickOSUI.SetActive(true);
            inputFieldTMP.text = "";
        }
        
    }
}
