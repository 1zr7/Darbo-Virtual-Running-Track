using UnityEngine;

public class AppInitializer : MonoBehaviour
{
    void Awake()
    {
        if (NavigationManager.Instance == null)
        {
            GameObject prefab = Resources.Load<GameObject>("NavigationManager");

            if (prefab != null)
            {
                Instantiate(prefab);
                Debug.Log("NavigationManager created ");
            }
            else
            {
                Debug.LogError("NavigationManager");
            }
        }
    }
}