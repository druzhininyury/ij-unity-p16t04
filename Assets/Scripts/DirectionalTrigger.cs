using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DirectionalTrigger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        _alarm.ActivateAlarm();
    }
    
    private void OnTriggerExit(Collider other)
    {
        _alarm.DeactivateAlarm();
    }
}
