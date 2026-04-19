using UnityEngine;
using System.Collections;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance;

    public IntervalManager intervalManager;

    public float distance = 0f;
    public int laps = 0;
    public float runTime = 0f;

    private float lapDistance = 400f;

    public bool useGPS = true;

    private IDistanceService distanceService;
    private int lastLap = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        if (intervalManager == null)
        {
            Debug.LogError("IntervalManager NOT FOUND");
        }

        if (useGPS)
        {
            distanceService = gameObject.AddComponent<GPSDistanceService>();
        }
        else
        {
            distanceService = new SimulatedDistanceService();
        }
    }

    void Update()
    {
        if (distanceService == null) return;

        if (intervalManager != null && intervalManager.isResting)
            return;

        distance = distanceService.GetDistance();

        runTime += Time.deltaTime;

        int currentLap = Mathf.FloorToInt(distance / lapDistance);

        if (currentLap > lastLap)
        {
            OnLapCompleted(currentLap);
            lastLap = currentLap;
        }

        laps = currentLap;
    }

    public void StartRun()
    {
        distanceService.StartTracking();

        if (intervalManager != null && intervalManager.isIntervalMode)
        {
            intervalManager.StartInterval();
        }
    }

    public void StopRun()
    {
        distanceService.StopTracking();
    }

    public void SetMode(bool useGPSMode)
    {
        useGPS = useGPSMode;

        if (distanceService != null)
        {
            distanceService.StopTracking();
        }

        if (useGPS)
        {
            distanceService = gameObject.AddComponent<GPSDistanceService>();
        }
        else
        {
            distanceService = new SimulatedDistanceService();
        }
    }

    public float GetPace()
    {
        if (distance <= 0) return 0;

        float km = distance / 1000f;
        return runTime / km;
    }

    public string GetFormattedPace()
    {
        float pace = GetPace();

        int minutes = Mathf.FloorToInt(pace / 60f);
        int seconds = Mathf.FloorToInt(pace % 60f);

        return minutes + ":" + seconds.ToString("00");
    }

    void OnLapCompleted(int lapNumber)
    {
        Debug.Log("Lap " + lapNumber + " completed");

        StartCoroutine(LapFeedback(lapNumber)); // ✅ Correct call
    }

    IEnumerator LapFeedback(int lapNumber)
    {
        var tts = FindFirstObjectByType<TextToSpeech>();

        
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayBeep();
        }

        yield return new WaitForSeconds(0.5f);

        if (tts != null)
        {
            string pace = GetFormattedPace();
            tts.Speak("Lap " + lapNumber + ". Pace " + pace);
        }
        else
        {
            Debug.LogWarning("TextToSpeech not found!");
        }
    }
}