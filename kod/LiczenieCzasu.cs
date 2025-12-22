using UnityEngine;

public class LiczenieCzasu : MonoBehaviour
{
    float sessionTime;
    float totalTime;

    void Start()
    {
        totalTime = PlayerPrefs.GetFloat("TotalPlayTime", 0f);
    }

    void Update()
    {
        sessionTime += Time.deltaTime;
    }

    void OnApplicationQuit()
    {
        SaveTime();
    }

    void OnApplicationPause(bool pause)
    {
        if (pause)
            SaveTime(); 
    }
    public (float Caly, float Sesja) GetTotalTime()
    {
        float calkowityCzas = totalTime + sessionTime;
        return (Caly: calkowityCzas, Sesja: sessionTime);
    }

    void SaveTime()
    {
        totalTime += sessionTime;
        sessionTime = 0f;

        PlayerPrefs.SetFloat("TotalPlayTime", totalTime);
        PlayerPrefs.Save();
    }
}
