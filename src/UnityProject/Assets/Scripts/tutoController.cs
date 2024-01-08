using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class tutoController : MonoBehaviour
    {
        public GameObject panelZqsdCaps;
        public GameObject panelSpaceCap;
        public GameObject panelECap;
        
        public bool zqsdPassable = true;
        public bool spacePassable = false;
        public bool ePassable = false;

        private void Start()
        {
            panelZqsdCaps.SetActive(true);
            panelSpaceCap.SetActive(false);
            panelECap.SetActive(false);   
        }

        private void Update()
        {
            if (zqsdPassable)
            {
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    StartCoroutine(HidePanelAfterDelay(5f,panelZqsdCaps));
                    StartCoroutine(ShowPanelAfterDelay(5f,panelSpaceCap));
                    zqsdPassable = !zqsdPassable;
                    spacePassable = !spacePassable;
                }
            }

            if (spacePassable)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(HidePanelAfterDelay(3f,panelSpaceCap));
                    StartCoroutine(ShowPanelAfterDelay(3f,panelECap));
                    spacePassable = !spacePassable;
                    ePassable = !ePassable;
                }
            }
            
            if (ePassable)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(HidePanelAfterDelay(3f,panelECap));
                    ePassable = !ePassable;
                }
            }
            
        }
        
        IEnumerator HidePanelAfterDelay(float delay,GameObject panel)
        {
            yield return new WaitForSeconds(delay);
            hidePanel(panel);
        }
        
        IEnumerator ShowPanelAfterDelay(float delay,GameObject panel)
        {
            yield return new WaitForSeconds(delay);
            showPanel(panel);
        }
        
        private void hidePanel(GameObject panel)
        {
            panel.SetActive(false);
        }
        
        private void showPanel(GameObject panel)
        {
            panel.SetActive(true);
        }
    }
}