using UnityEngine;
namespace Controllers
{
    public class ComputerServerController : MonoBehaviour
    {
        private bool _isRunning;
        public bool isVisible;
        public GameObject pauseMenuUI;
        public GameObject computer;
        private ComputerServerController _serveurControllerScript;
        private FPSController _script;
        public GameObject player;
       
        [SerializeField] public GameObject screen;

        public void Update()
        {
            
            
        }




        public void WindowsLaunch()
        {
            //Cursor.visible = isVisible;
            //Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
            OnDisplay();
            _script = player.GetComponent<FPSController>();
            _script.enabled = false;

        }

        void OnDisplay()
        {
            if (!_isRunning)
            {
                ComputerStateChange();
                pauseMenuUI.SetActive(true);
            }
        }

        public void WindowsQuit()
        {
            pauseMenuUI.SetActive(false);
            ComputerStateChange();
            _serveurControllerScript = computer.GetComponent<ComputerServerController>();
            _serveurControllerScript.enabled = false;
            _script.enabled = true;
        }




        private void ComputerStateChange()
        {
            _isRunning = !_isRunning;
            isVisible = !isVisible;
            Cursor.visible = isVisible;
            Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        }


        
    }
}



