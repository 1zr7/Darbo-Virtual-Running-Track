using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance;

    public float distance = 0f;
    public int laps = 0;

    private float lapDistance = 400f;

    public bool useGPS = true;

    private IDistanceService distanceService;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
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

        distance = distanceService.GetDistance();
        laps = Mathf.FloorToInt(distance / lapDistance);
    }

    public void StartRun()
    {
        distanceService.StartTracking();
    }

    public void StopRun()
    {
        distanceService.StopTracking();
    }
}