using UnityEngine;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;

public class authManager : MonoBehaviour
{
    public static authManager Instance;

    private FirebaseAuth auth;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    async void Start()
    {
        await InitializeFirebase();
    }

    async Task InitializeFirebase()
    {
        var dependencyStatus = await FirebaseApp.CheckAndFixDependenciesAsync();
        if (dependencyStatus == DependencyStatus.Available)
        {
            auth = FirebaseAuth.DefaultInstance;
            Debug.Log("Firebase Ready");
        }
        else
        {
            Debug.LogError("Firebase not ready");
        }
    }

    public async Task SignUp(string email, string password)
    {
        await auth.CreateUserWithEmailAndPasswordAsync(email, password);
        Debug.Log("User Created");
    }

    public async Task Login(string email, string password)
    {
        await auth.SignInWithEmailAndPasswordAsync(email, password);
        Debug.Log("User Logged In");
    }
}