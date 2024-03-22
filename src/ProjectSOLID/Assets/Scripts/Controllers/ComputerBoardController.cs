using UnityEngine;
namespace Controllers
{
    public class ComputerBoardController : MonoBehaviour
    {
        private bool _isRunning;
        public bool isVisible;
        public GameObject pauseMenuUI;
        public GameObject computer;
        private ComputerBoardController _computerControllerScript;
        private FPSController _script;
        public GameObject player;
        public GameObject greenLight1;
        public GameObject redLight1;
        public GameObject greenLight2;
        public GameObject redLight2;
        public GameObject greenLight3;
        public GameObject redLight3;
        public GameObject greenLight4;
        public GameObject redLight4;
        public GameObject greenLight5;
        public GameObject redLight5;
        public GameObject greenLight6;
        public GameObject redLight6;
        public GameObject greenLight7;
        public GameObject redLight7;
        public GameObject greenLight8;
        public GameObject redLight8;
        public GameObject greenLight9;
        public GameObject redLight9;
        private bool switch1isOn = false;
        private bool switch2isOn = false;
        private bool switch3isOn = false;
        private bool switch4isOn = false;
        private bool switch5isOn = false;
        private bool switch6isOn = false;
        private bool switch7isOn = false;
        private bool switch8isOn = false;
        private bool isUnlock = false;

        [SerializeField] public GameObject screen;

        public void Update()
        {
            screen.SetActive(true);
            unlockBoard();
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
            _computerControllerScript = computer.GetComponent<ComputerBoardController>();
            _computerControllerScript.enabled = false;
            _script.enabled = true;
        }

        public void unlockBoard()
        {
            isUnlock = (!((switch1isOn ^ switch2isOn) && switch3isOn) && !switch4isOn) && (switch8isOn || (switch5isOn && switch6isOn && switch7isOn));
            if (isUnlock)
            {
                redLight9.SetActive(false);
                greenLight9.SetActive(true);
            }
        }

 

        private void ComputerStateChange()
        {
            _isRunning = !_isRunning;
            isVisible = !isVisible;
            Cursor.visible = isVisible;
            Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        }

        public void switchMode(int id)
        {
            if (id == 1)
            {
                if (switch1isOn)
                {
                    redLight1.SetActive(true);
                    greenLight1.SetActive(false);
                }
                else
                {
                    redLight1.SetActive(false);
                    greenLight1.SetActive(true);
                }
            }
            if (id == 2)
            {
                if (switch1isOn)
                {
                    redLight2.SetActive(true);
                    greenLight2.SetActive(false);
                }
                else
                {
                    redLight2.SetActive(false);
                    greenLight2.SetActive(true);
                }
            }
            if (id == 3)
            {
                if (switch1isOn)
                {
                    redLight3.SetActive(true);
                    greenLight3.SetActive(false);
                }
                else
                {
                    redLight3.SetActive(false);
                    greenLight3.SetActive(true);
                }
            }
            if (id == 4)
            {
                if (switch1isOn)
                {
                    redLight4.SetActive(true);
                    greenLight4.SetActive(false);
                }
                else
                {
                    redLight4.SetActive(false);
                    greenLight4.SetActive(true);
                }
            }
            if (id == 5)
            {
                if (switch1isOn)
                {
                    redLight5.SetActive(true);
                    greenLight5.SetActive(false);
                }
                else
                {
                    redLight5.SetActive(false);
                    greenLight5.SetActive(true);
                }
            }
            if (id == 6)
            {
                if (switch1isOn)
                {
                    redLight6.SetActive(true);
                    greenLight6.SetActive(false);
                }
                else
                {
                    redLight6.SetActive(false);
                    greenLight6.SetActive(true);
                }
            }
            if (id == 7)
            {
                if (switch1isOn)
                {
                    redLight7.SetActive(true);
                    greenLight7.SetActive(false);
                }
                else
                {
                    redLight7.SetActive(false);
                    greenLight7.SetActive(true);
                }
            }
            if (id == 8)
            {
                if (switch1isOn)
                {
                    redLight8.SetActive(true);
                    greenLight8.SetActive(false);
                }
                else
                {
                    redLight8.SetActive(false);
                    greenLight8.SetActive(true);
                }
            }
        }
    }
}



