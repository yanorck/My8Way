using UnityEngine;

public static class GameControler
{
    private static int collectableCount;

    public static bool gameOver
    {
        get {return collectableCount <= 0;}
    }

    public static void Init()
    {
        collectableCount = 8;
    }

    public static void Collect()
    {
        collectableCount--;
    }
}
