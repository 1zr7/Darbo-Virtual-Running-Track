using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
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
}