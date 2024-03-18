using System.Collections.Generic;

namespace Controllers
{
    public class SwitchBoardController
    {
        private readonly List<bool> _switchStates = new List<bool>();
        private bool _switchBoardComplete = false;
        
        void Start()
        {
            for (int i = 0; i < 8; i++)
            {
                _switchStates.Add(false);
            }
        }
        
        void Update()
        {
            _switchBoardComplete = SwitchesAreGood();
        }
        
        public bool GetSwitchState(int switchIndex)
        {
            return _switchStates[switchIndex];
        }
        
        public void ToggleSwitchState(int switchIndex)
        {
            _switchStates[switchIndex] = !_switchStates[switchIndex];
        }
        
        public bool SwitchesAreGood()
        {
            if (HaveGreatCombination())
            {
                return true;
            }
            else
            {
                return false;
            } 
        }

        private bool HaveGreatCombination()
        {
            return GetSwitchState(2) && GetSwitchState(3) == false && GetSwitchState(7) == true;
        }
    }
}