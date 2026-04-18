using UnityEngine;
using System.Collections;

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
        StartCoroutine(SpeakRoutine(text));
    }

    IEnumerator SpeakRoutine(string text)
    {
        AudioManager.Instance?.PlayBeep();
        yield return new WaitForSeconds(0.4f);

        if (tts != null)
        {
            tts.Call<int>("speak", text, 0, null, null);
        }
    }
}