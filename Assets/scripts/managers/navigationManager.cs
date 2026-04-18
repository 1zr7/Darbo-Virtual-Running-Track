using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    public static NavigationManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // =============================
    // Navigation Methods
    // =============================

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("mainMenuScene");
    }

    public void GoToRun()
    {
        SceneManager.LoadScene("runScene");
    }

    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("leaderboardScene");
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene("loginScene");
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");

        Application.Quit();
    }
}