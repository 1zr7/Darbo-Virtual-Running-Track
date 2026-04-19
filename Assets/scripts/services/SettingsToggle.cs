using UnityEngine;

public class SettingsToggle : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false); 
    }

    public void Toggle()
    {
        panel.SetActive(!panel.activeSelf);
    }
}