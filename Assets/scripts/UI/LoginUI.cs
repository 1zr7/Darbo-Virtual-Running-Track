using UnityEngine;
using TMPro;

public class loginUI : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    public async void OnSignUp()
    {
        await authManager.Instance.SignUp(emailInput.text, passwordInput.text);
    }

    public async void OnLogin()
    {
        await authManager.Instance.Login(emailInput.text, passwordInput.text);
    }
}