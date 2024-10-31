using UnityEngine;
using TMPro;

[RequireComponent (typeof(TextMeshProUGUI))]
public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = $"Score: {GameStats.Score.ToString("00000000")}";

    }
}
