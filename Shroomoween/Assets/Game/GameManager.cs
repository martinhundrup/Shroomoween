using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Game Speed")]
    [SerializeField] private float baseSpeed = 2f;           // Initial speed of the game
    [SerializeField] private float speedIncreaseRate = 0.1f; // Rate at which the speed increases over time
    [SerializeField] private float maxSpeed = 20f;           // Maximum speed to limit the increase

   

    [Header("Score")]
    [SerializeField] private float scoreMultiplier;

    private void Awake()
    {
        GameStats.GameSpeed = baseSpeed;
        GameStats.Score = 0;
    }

    private void Update()
    {
        // score
        GameStats.Score += Time.deltaTime * scoreMultiplier * GameStats.GameSpeed;

        // speed
        if (GameStats.GameSpeed < maxSpeed)
        {
            GameStats.GameSpeed += speedIncreaseRate * Time.deltaTime;
        }

        

        //Debug.Log("Current Speed: " + stats.GameSpeed);
    }
}
