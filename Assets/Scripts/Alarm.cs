using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ActivateAlarm()
    {
        _audioSource.Play();
    }

    public void DeactivateAlarm()
    {
        _audioSource.Stop();
    }
}
