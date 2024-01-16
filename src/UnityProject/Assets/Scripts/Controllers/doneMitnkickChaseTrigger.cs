using UnityEngine;

namespace Controllers
{
    public class doneMitnkickChaseTrigger : MonoBehaviour, ITriggerable
    {
        private bool hackIsDone= false;
        public void Trigger()
        {
            if (hackIsDone)
            {
                gameObject.SetActive(true);
            }
        }
        
        private void setHackState(bool state)
        {
            hackIsDone = state;
        }
    }
}