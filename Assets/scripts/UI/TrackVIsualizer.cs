using UnityEngine;
using System.Collections.Generic;

public class TrackVisualizer : MonoBehaviour
{
    [Header("Track Shape")]
    public float width = 6f;
    public float height = 10f;
    public float cornerRadius = 2f;
    public int cornerSegments = 20;
    public Transform runnerDot;
    [Header("Line Renderers")]
    public LineRenderer baseLine;     
    public LineRenderer progressLine; 

    private Vector3[] fullPoints;

    void Start()
    {
        GenerateTrack();
        DrawBaseTrack();
    }

    void Update()
    {
        float lapProgress = 0f;

        if (RunManager.Instance != null)
        {
            lapProgress = (RunManager.Instance.distance % 400f) / 400f;
        }

        UpdateProgress();
        UpdateRunnerDot(lapProgress);
    }

    void GenerateTrack()
    {
        float r = Mathf.Min(cornerRadius, width / 2f, height / 2f);

        float hw = width / 2f;
        float hh = height / 2f;

        Vector3[] centers = new Vector3[]
        {
            new Vector3( hw - r,  hh - r, 0),   // Top-Right
            new Vector3(-hw + r,  hh - r, 0),   // Top-Left
            new Vector3(-hw + r, -hh + r, 0),   // Bottom-Left
            new Vector3( hw - r, -hh + r, 0),   // Bottom-Right
        };

        float[] startAngles = { 0f, 90f, 180f, 270f };

        List<Vector3> points = new List<Vector3>();

        for (int c = 0; c < 4; c++)
        {
            for (int i = 0; i <= cornerSegments; i++)
            {
                float angle = Mathf.Deg2Rad * (startAngles[c] + (90f / cornerSegments) * i);

                float x = centers[c].x + r * Mathf.Cos(angle);
                float y = centers[c].y + r * Mathf.Sin(angle);

                points.Add(new Vector3(x, y, 0));
            }
        }
        
        points.Add(points[0]);

        fullPoints = points.ToArray();
    }

    void DrawBaseTrack()
    {
        if (baseLine == null) return;

        baseLine.useWorldSpace = true;
        baseLine.positionCount = fullPoints.Length;
        baseLine.SetPositions(fullPoints);
    }
    
    void UpdateRunnerDot(float progress)
    {
        if (runnerDot == null || fullPoints == null) return;

        int index = Mathf.FloorToInt(progress * (fullPoints.Length - 1));
        index = Mathf.Clamp(index, 0, fullPoints.Length - 1);

        runnerDot.position = fullPoints[index];
    }

    void UpdateProgress()
    {
        if (progressLine == null || fullPoints == null) return;

        float lapProgress = 0f;

        if (RunManager.Instance != null)
        {
            lapProgress = (RunManager.Instance.distance % 400f) / 400f;
        }

        int count = Mathf.FloorToInt(fullPoints.Length * lapProgress);
        count = Mathf.Clamp(count, 1, fullPoints.Length);

        progressLine.useWorldSpace = true;
        progressLine.positionCount = count;

        for (int i = 0; i < count; i++)
        {
            progressLine.SetPosition(i, fullPoints[i]);
        }
    }
}