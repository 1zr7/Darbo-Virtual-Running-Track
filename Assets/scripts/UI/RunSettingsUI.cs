using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RunSettingsUI : MonoBehaviour
{
    [Header("Tracking Mode")]
    public Toggle modeToggle; 

    [Header("Interval Mode")]
    public Toggle intervalToggle;
    public TMP_InputField distanceInput;
    public TMP_InputField restInput;

    public IntervalManager intervalManager;

    void Start()
    {
        modeToggle.isOn = RunManager.Instance.useGPS;
    }

    public void OnToggleChanged()
    {
        RunManager.Instance.SetMode(modeToggle.isOn);
    }

    public void ApplyIntervalSettings()
    {
        if (intervalManager == null)
        {
            Debug.LogError("Interval was not assigned!");
            return;
        }
        
        intervalManager.isIntervalMode = intervalToggle.isOn;
        
        if (float.TryParse(distanceInput.text, out float dist))
        {
            intervalManager.intervalDistance = dist;
        }

       
        if (float.TryParse(restInput.text, out float rest))
        {
            intervalManager.restTime = rest;
        }

        Debug.Log("interval settings applied");
    }
}