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

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); 
        }
    }

    public void PlayBeep()
    {
        if (audioSource != null && beepClip != null)
        {
            audioSource.PlayOneShot(beepClip);
        }
        else
        {
            Debug.LogWarning("Beep audio missing");
        }
    }

    public void PlayCountdown()
    {
        audioSource.PlayOneShot(countdownClip);
    }
}