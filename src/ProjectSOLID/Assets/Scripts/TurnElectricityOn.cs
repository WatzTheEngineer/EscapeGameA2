using UnityEngine;

public class TurnElectricityOn : MonoBehaviour, ITriggerable
{
    private bool _isOn;

    public void Trigger()
    {
        gameObject.SetActive(true);
        _isOn = true;
    }

    public bool GetElectricityState()
    {
        return _isOn;
    }
}