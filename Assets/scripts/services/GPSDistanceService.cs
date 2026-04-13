using UnityEngine;
using System.Collections;
using UnityEngine.Android;

public class GPSDistanceService : MonoBehaviour, IDistanceService
{
    private float distance = 0f;
    private Vector2 lastPosition;
    private bool isTracking = false;

    public void StartTracking()
    {
        isTracking = true;
        StartCoroutine(StartGPS());
    }

    public void StopTracking()
    {
        isTracking = false;
        Input.location.Stop();
    }

    public float GetDistance()
    {
        return distance;
    }

    IEnumerator StartGPS()
    {
        // Request permission FIRST
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            yield return new WaitForSeconds(2);
        }

        // check if GPS enabled
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("GPS not enabled");
            yield break;
        }

        // Start GPS
        Input.location.Start();

        int maxWait = 10;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            Debug.Log("Initializing GPS...");
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (Input.location.status != LocationServiceStatus.Running)
        {
            Debug.Log("GPS failed");
            yield break;
        }

        Debug.Log("GPS Running ");

        lastPosition = GetCurrentPosition();

        while (isTracking)
        {
            Vector2 currentPosition = GetCurrentPosition();

            float delta = Vector2.Distance(lastPosition, currentPosition) * 111139f;

            if (delta > 0.5f) // filter noise
            {
                distance += delta;
                lastPosition = currentPosition;

                Debug.Log("Distance: " + distance);
            }

            yield return new WaitForSeconds(1f);
        }
    }

    Vector2 GetCurrentPosition()
    {
        return new Vector2(
            Input.location.lastData.latitude,
            Input.location.lastData.longitude
        );
    }
}