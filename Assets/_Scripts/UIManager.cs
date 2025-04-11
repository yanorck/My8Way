using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text finalTimeText;
    public TMP_Text finalScoreText;
    public GameObject endGamePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameControler.gameOver)
        {
            endGamePanel.SetActive(true);
            float finalTime = TimerManager.GetFinalTime();
            finalTimeText.text = "Tempo Total: " + TimerManager.FormatTime(finalTime);
            finalScoreText.text = "Pontos: " + GameControler.GetScore().ToString();
        }
    }
}
