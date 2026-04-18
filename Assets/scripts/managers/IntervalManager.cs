using UnityEngine;

public class IntervalManager : MonoBehaviour
{
    public float intervalDistance = 200f; 
    public float restTime = 30f; 

    private float startDistance = 0f;
    public float restTimer = 0f;

    public bool isIntervalMode = false;
    public bool isResting = false;

    public void StartInterval()
    {
        startDistance = RunManager.Instance.distance;
        isResting = false;
    }

    void Update()
    {
        if (!isIntervalMode || !RunManager.Instance) return;

        if (!isResting)
        {
            float currentDistance = RunManager.Instance.distance;

            if (currentDistance - startDistance >= intervalDistance)
            {
                StartRest();
            }
        }
        else
        {
            restTimer -= Time.deltaTime;
            restTimer = Mathf.Max(restTimer, 0f);


            if (restTimer <= 3f && restTimer > 2.9f)
            {
                AudioManager.Instance?.PlayCountdown();
            }

            if (restTimer <= 0)
            {
                StartNextInterval();
            }
        }
    }

    void StartRest()
    {
        isResting = true;
        restTimer = restTime;

        Debug.Log("Rest started");
        FindObjectOfType<TextToSpeech>()?.Speak("Rest started");
    }

    void StartNextInterval()
    {
        isResting = false;
        startDistance = RunManager.Instance.distance;

        Debug.Log("interval session started");
        
        var tts = FindObjectOfType<TextToSpeech>();
        FindObjectOfType<TextToSpeech>()?.Speak("Run");
    }
}