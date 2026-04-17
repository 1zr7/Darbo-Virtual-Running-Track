using UnityEngine;
using TMPro;

public class RunUI : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI lapsText;

    public TextMeshProUGUI stateText;
    public TextMeshProUGUI timerText;
    
    void Update()
    {
        var run = RunManager.Instance;
        var interval = run.intervalManager;
        

       
        distanceText.text = "Distance: " + run.distance.ToString("F1") + " m";
        lapsText.text = "Laps: " + run.laps;

        
        if (interval != null && interval.isIntervalMode)
        {
            if (interval.isResting)
            {
                stateText.text = "Resting";
                timerText.text = "Rest: " + interval.restTimer.ToString("F0") + "s";
            }
            else
            {
                stateText.text = "Running Interval";

                float progress = run.distance % interval.intervalDistance;
                timerText.text = "Run: " + progress.ToString("F0") + "/" + interval.intervalDistance + "m";
            }
        }
        else
        {
            stateText.text = "Free Run";
            timerText.text = "";
        }
    }
}