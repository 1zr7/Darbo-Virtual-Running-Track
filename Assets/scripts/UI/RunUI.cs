using UnityEngine;
using TMPro;

public class RunUI : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI lapsText;

    void Update()
    {
        distanceText.text = "Distance: " + RunManager.Instance.distance.ToString("F1") + " m";
        lapsText.text = "Laps: " + RunManager.Instance.laps;
    }
}