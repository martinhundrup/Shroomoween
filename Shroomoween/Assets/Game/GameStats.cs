using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObejcts/Game Stats")]
public class GameStats : ScriptableObject
{
    [SerializeField] private float gameSpeed;
    [SerializeField] private int score;

    public float GameSpeed
    {
        get { return gameSpeed; }
        set { gameSpeed = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }
}
