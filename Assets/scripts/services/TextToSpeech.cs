using UnityEngine;

public class TextToSpeech : MonoBehaviour
{
    AndroidJavaObject tts;

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            tts = new AndroidJavaObject("android.speech.tts.TextToSpeech", context, null);
        }
    }

    public void Speak(string text)
    {
        if (tts != null)
        {
            tts.Call<int>("speak", text, 0, null, null);
        }
    }
}