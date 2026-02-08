using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private readonly float MinVolume = 0.0f;
    private readonly float MaxVolume = 1.0f;
    
    private AudioSource _audioSource;
    private float _heatUpTime = 2.0f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = MinVolume;
    }

    public void ActivateAlarm()
    {
        StartCoroutine(TurnOnCoroutine());
    }

    public void DeactivateAlarm()
    {
        StartCoroutine(TurnOffCoroutine());
    }

    private IEnumerator TurnOnCoroutine()
    {
        StopCoroutine(TurnOffCoroutine());
        float timer = 0.0f;
        _audioSource.Play();

        yield return null;

        while (timer < _heatUpTime)
        {
            timer = Mathf.MoveTowards(timer, _heatUpTime, Time.deltaTime);
            _audioSource.volume = timer / _heatUpTime;
            yield return null;
        }
    }

    private IEnumerator TurnOffCoroutine()
    {
        StopCoroutine(TurnOnCoroutine());
        float timer = 0.0f;

        yield return null;

        while (timer < _heatUpTime)
        {
            timer = Mathf.MoveTowards(timer, _heatUpTime, Time.deltaTime);
            _audioSource.volume = 1.0f - timer / _heatUpTime;
            yield return null;
        }

        _audioSource.Stop();
    }
}
