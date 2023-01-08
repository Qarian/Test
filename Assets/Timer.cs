using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private string key = "Highest Time";
    
    private float startTime;

    private TMP_Text currentTime;
    private TMP_Text highscore;

    private void Awake()
    {
        StartTimer();

        if (PlayerPrefs.HasKey(key))
        {
            highscore.text = PlayerPrefs.GetFloat(key).ToString();
        }
        else
        {
            highscore.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        currentTime.text = GetTime().ToString();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        float time = GetTime();
        if (PlayerPrefs.HasKey(key))
        {
            if (PlayerPrefs.GetFloat(key) > time)
            {
                PlayerPrefs.SetFloat(key, time);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(key, time);
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
    }

    public float GetTime()
    {
        return Time.time - startTime;
    }
}
