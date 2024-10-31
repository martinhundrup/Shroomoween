using UnityEngine;

public static class GameStats
{
    [SerializeField] private static float gameSpeed;
    [SerializeField] private static float score;
    [SerializeField] private static int ammo;

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
}
