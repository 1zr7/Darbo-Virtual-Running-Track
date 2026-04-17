using UnityEngine;

public class SimulatedDistanceService : IDistanceService
{
    private float distance = 0f;
    private float speed = 2f;
    private bool isTracking = false;

    public void StartTracking()
    {
        Debug.Log("simulation started");
        isTracking = true;
    }

    public void StopTracking()
    {
        isTracking = false;
    }

    public float GetDistance()
    {
        if (isTracking)
        {
            distance += Time.deltaTime * speed;
        }
        return distance;
    }
}