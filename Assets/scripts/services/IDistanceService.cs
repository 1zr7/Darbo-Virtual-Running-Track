using UnityEngine;

public interface IDistanceService
{
    float GetDistance();
    void StartTracking();
    void StopTracking();
}
