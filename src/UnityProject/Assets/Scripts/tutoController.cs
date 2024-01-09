using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class TutoController : MonoBehaviour
    {
        [SerializeField] private GameObject panelZqsdCaps;
        [SerializeField] private GameObject panelSpaceCap;
        [SerializeField] private GameObject panelECap;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float waitTimeBetweenFade;

        private bool _isZqsdActive = true;
        private bool _isSpaceActive;
        private bool _isEActive;

        private void Start()
        {
            ActivatePanel(panelZqsdCaps, true);
            ActivatePanel(panelSpaceCap, false);
            ActivatePanel(panelECap, false);
        }

        private void Update()
        {
            if (canvasGroup.alpha >= 1)
            {
                CheckForKeyPress();
            }
        }

        private void CheckForKeyPress()
        {
            if (_isZqsdActive && IsZqsdKey())
            {
                StartCoroutine(TransitionToNextPanel(panelZqsdCaps, panelSpaceCap, waitTimeBetweenFade));
                _isZqsdActive = false;
                _isSpaceActive = true;
            }
            else if (_isSpaceActive && Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(TransitionToNextPanel(panelSpaceCap, panelECap, waitTimeBetweenFade));
                _isSpaceActive = false;
                _isEActive = true;
            }
            else if (_isEActive && Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(FadeOutPanel(panelECap));
                _isEActive = false;
            }
        }

        private IEnumerator TransitionToNextPanel(GameObject currentPanel, GameObject nextPanel, float delay)
        {
            yield return StartCoroutine(FadeOutPanel(currentPanel));
            yield return StartCoroutine(FadeInPanel(nextPanel, delay));
        }

        private IEnumerator FadeOutPanel(GameObject panel)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime;
                yield return null;
            }
            ActivatePanel(panel, false);
        }

        private IEnumerator FadeInPanel(GameObject panel, float delay)
        {
            yield return new WaitForSeconds(delay);
            ActivatePanel(panel, true);
            canvasGroup.alpha = 0;
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;
                yield return null;
            }
        }

        private bool IsZqsdKey()
        {
            return Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                   Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D);
        }

        private void ActivatePanel(GameObject panel, bool isActive)
        {
            panel.SetActive(isActive);
        }
    }
}