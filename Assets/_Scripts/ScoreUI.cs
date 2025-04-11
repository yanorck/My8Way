using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;

    void Update()
    {
        scoreText.text = $"Pontos: {GameControler.GetScore()}";
    }
}