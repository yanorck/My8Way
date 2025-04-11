using UnityEngine;

public static class GameControler
{
    private static bool isGameOver = false;
    private static int score = 0;

    public static bool gameOver
    {
        get { return isGameOver; }
    }

    public static void Init()
    {
        isGameOver = false;
        score = 0;
    }

    public static void ForceGameOver()
    {
        isGameOver = true;
    }
    public static void AddScore(int value)
    {
        score += value;
    }

    public static int GetScore()
    {
        return score;
    }
}