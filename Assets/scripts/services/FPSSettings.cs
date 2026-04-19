using System;
using UnityEngine;

public class FPSSettings : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 90;
        QualitySettings.vSyncCount = 0;
    }
}
