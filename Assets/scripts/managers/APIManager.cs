using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

[System.Serializable]
public class RunData
{
    public string user;
    public float distance;
    public int laps;
    public float time;
    public string pace;
}

public class APIManager : MonoBehaviour
{
    public string baseURL = "http://192.168.56.1:3000/api/runs";

    public void SaveRun()
    {
        StartCoroutine(SaveRunCoroutine());
    }

    IEnumerator SaveRunCoroutine()
    {
        RunData run = new RunData
        {
            user = "Player1",
            distance = RunManager.Instance.distance,
            laps = RunManager.Instance.laps,
            time = RunManager.Instance.runTime,
            pace = RunManager.Instance.GetFormattedPace()
        };

        string json = JsonUtility.ToJson(run);

        Debug.Log("Sending JSON: " + json);

        UnityWebRequest request = new UnityWebRequest(baseURL + "/save", "POST");

        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Run saved");
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }
}