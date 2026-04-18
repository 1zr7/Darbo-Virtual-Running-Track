using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

[System.Serializable]
public class LeaderboardEntry
{
    public string user;
    public int bestLaps;
}

[System.Serializable]
public class LeaderboardList
{
    public LeaderboardEntry[] entries;
}

public class LeaderboardManager : MonoBehaviour
{
    public string url = "http://localhost:3000/api/runs/leaderboard";
    public TextMeshProUGUI leaderboardText;

    void Start()
    {
        StartCoroutine(GetLeaderboard());
    }

    IEnumerator GetLeaderboard()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            
            json = "{\"entries\":" + json + "}";

            LeaderboardList data = JsonUtility.FromJson<LeaderboardList>(json);

            DisplayLeaderboard(data.entries);
        }
        else
        {
            Debug.LogError(request.error);
        }
    }

    void DisplayLeaderboard(LeaderboardEntry[] entries)
    {
        leaderboardText.text = "Leaderboard\n\n";

        for (int i = 0; i < entries.Length; i++)
        {
            leaderboardText.text +=
                (i + 1) + ". " +
                entries[i].user +
                " - " +
                entries[i].bestLaps + " laps\n";
        }
    }
    public void RefreshLeaderboard()
    {
        StartCoroutine(GetLeaderboard());
    }
}