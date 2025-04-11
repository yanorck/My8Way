using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text finalTimeText;
    private float timer = 0f;
    private bool counting = true;

    void Update()
    {
        if (counting)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay();
        }

        if (GameControler.gameOver)
        {
            counting = false;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        int milliseconds = Mathf.FloorToInt((timer * 1000f) % 1000f);

        timerText.text = $"{minutes:00}:{seconds:00}:{milliseconds:000}";
    }
    public static float GetFinalTime()
    {
        return instance.timer;
    }
    
    public static string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);

        return $"{minutes:00}:{seconds:00}:{milliseconds:000}";
    }

    private static TimerManager instance;

    void Awake()
    {
        instance = this;
    }
}