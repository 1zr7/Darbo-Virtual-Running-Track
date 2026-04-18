using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;

    public AudioClip beepClip;
    public AudioClip countdownClip;

    void Awake()
    {
        Instance = this;
    }

    public void PlayBeep()
    {
        audioSource.PlayOneShot(beepClip);
    }

    public void PlayCountdown()
    {
        audioSource.PlayOneShot(countdownClip);
    }
}