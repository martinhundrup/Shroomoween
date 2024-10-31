using UnityEngine;
using System;

public static class GameStats
{
    [SerializeField] private static float gameSpeed;
    [SerializeField] private static float score;
    [SerializeField] private static int ammo;
    [SerializeField] private static bool gameStart = false;
    [SerializeField] private static bool gameOver = false;

    public static event Action OnGameRestart;

    public static void RestartGame()
    {
        OnGameRestart?.Invoke();
    }

    public static float GameSpeed
    {
        get { return gameSpeed; }
        set { gameSpeed = value; }
    }

    public static float Score
    {
        get { return score; }
        set { score = value; }
    }

    public static int Ammo
    {
        get { return ammo; }
        set { ammo = value; }
    }

    public static bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    public static bool GameStart
    {
        get { return gameStart; }
        set { gameStart = value; }
    }
}
