using System.Collections;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class MitnickUIController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private GameObject basePanel;
        private GameObject _loadingPanel;
        private string _nextText;

        private void Start()
        {
            _loadingPanel = basePanel;
        }

        private IEnumerator ReloadText()
        {
            yield return StartCoroutine(FadeOutPanel(_loadingPanel));
            _loadingPanel.SetActive(false);
            _loadingPanel = Instantiate(basePanel, gameObject.transform, true);
            _loadingPanel.SetActive(true);
            var tmp = _loadingPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            tmp.text = _nextText;
            yield return StartCoroutine(FadeInPanel(_loadingPanel, .25f));
            yield return StartCoroutine(FadeOutPanel(_loadingPanel));
        }

        public IEnumerator FadeOutPanel(GameObject panel)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime;
                yield return null;
            }
        }

        public IEnumerator FadeInPanel(GameObject panel, float delay)
        {
            yield return new WaitForSeconds(delay);
            canvasGroup.alpha = 0;
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;
                yield return null;
            }
        }

        public void ShowText(string textToSend)
        {
            _nextText = textToSend;
            StartCoroutine(ReloadText());
        }
    }
}