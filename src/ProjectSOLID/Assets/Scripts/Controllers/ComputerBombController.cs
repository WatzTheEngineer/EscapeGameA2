using UnityEngine;
namespace Controllers
{
    public class ComputerBombController : MonoBehaviour
    {
        private bool _isRunning;
        public bool isVisible;
        public GameObject pauseMenuUI;
        public GameObject computer;
        private ComputerBombController _computerControllerScript;
        private FPSController _script;
        public GameObject player;
        public GameObject greenLight;
        public GameObject redLight;
        
    
        [SerializeField] public GameObject screen;
    
        public void Update()
        {
            screen.SetActive(true);
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
            _computerControllerScript = computer.GetComponent<ComputerBombController>();
            _computerControllerScript.enabled = false;
            _script.enabled = true;
        }
    
        public void Switchlight()
        {
            greenLight.SetActive(false);
            redLight.SetActive(true);
    
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



