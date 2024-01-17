
using System.Collections;
using UnityEngine;

namespace Controllers
{
    public class TutorialController : MonoBehaviour
    {
        [SerializeField] public GameObject zqsdPanel;
        [SerializeField] public GameObject spacePanel;
        [SerializeField] public GameObject ePanel;
        [SerializeField] public GameObject clickPanel;
        [SerializeField] public GameObject shiftPanel;
        [SerializeField] public GameObject tabPanel;
        [SerializeField] public CanvasGroup canvasGroup;
        [SerializeField] public float waitTimeBetweenFade;
        [SerializeField] private GameObject MitnickUI;

        private bool _isClickActive;
        private bool _isEActive;
        private bool _isShiftActive;
        private bool _isSpaceActive;
        private bool _isTabActive;

        private bool _isZqsdActive = true;

        private void Start()
        {
            ActivatePanel(zqsdPanel, true);
            ActivatePanel(spacePanel, false);
            ActivatePanel(ePanel, false);
            ActivatePanel(clickPanel, false);
            ActivatePanel(shiftPanel, false);
            ActivatePanel(tabPanel, false);
        }

        private void Update()
        {
            if (canvasGroup.alpha >= 1) CheckForKeyPress();
        }

        private void CheckForKeyPress()
        {
            if (_isZqsdActive && IsZqsdKey())
            {
                StartCoroutine(TransitionToNextPanel(zqsdPanel, spacePanel, waitTimeBetweenFade));
                _isZqsdActive = false;
                _isSpaceActive = true;
            }
            else if (_isSpaceActive && Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(TransitionToNextPanel(spacePanel, ePanel, waitTimeBetweenFade));
                _isSpaceActive = false;
                _isEActive = true;
            }
            else if (_isEActive && Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(TransitionToNextPanel(ePanel, clickPanel, waitTimeBetweenFade));
                _isEActive = false;
                _isClickActive = true;
            }
            else if (_isClickActive && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
            {
                StartCoroutine(TransitionToNextPanel(clickPanel, shiftPanel, waitTimeBetweenFade));
                _isClickActive = false;
                _isShiftActive = true;
            }
            else if (_isShiftActive && Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(TransitionToNextPanel(shiftPanel, tabPanel, waitTimeBetweenFade));
                _isShiftActive = false;
                _isTabActive = true;
            }
            else if (_isTabActive && Input.GetKeyDown(KeyCode.Tab))
            {
                StartCoroutine(FadeOutPanel(tabPanel));
                _isTabActive = false;
                MitnickUI.SetActive(true);
            }
        }

        public IEnumerator TransitionToNextPanel(GameObject currentPanel, GameObject nextPanel, float delay)
        {
            yield return StartCoroutine(FadeOutPanel(currentPanel));
            yield return StartCoroutine(FadeInPanel(nextPanel, delay));
        }

        public IEnumerator FadeOutPanel(GameObject panel)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime;
                yield return null;
            }

            ActivatePanel(panel, false);
        }

        public IEnumerator FadeInPanel(GameObject panel, float delay)
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

        public bool IsZqsdKey()
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