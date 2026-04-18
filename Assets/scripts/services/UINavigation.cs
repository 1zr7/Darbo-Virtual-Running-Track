using UnityEngine;

public class UINavigation : MonoBehaviour
{
    public void GoToMainMenu()
    {
        NavigationManager.Instance.GoToMainMenu();
    }

    public void GoToRun()
    {
        NavigationManager.Instance.GoToRun();
    }

    public void GoToLeaderboard()
    {
        NavigationManager.Instance.GoToLeaderboard();
    }

    public void GoToLogin()
    {
        NavigationManager.Instance.GoToLogin();
    }

    public void ExitGame()
    {
        NavigationManager.Instance.ExitGame();
    }
}