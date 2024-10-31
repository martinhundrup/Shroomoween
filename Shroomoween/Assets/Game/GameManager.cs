using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Game Speed")]
    [SerializeField] private float baseSpeed = 2f;           // Initial speed of the game
    [SerializeField] private float speedIncreaseRate = 0.1f; // Rate at which the speed increases over time
    [SerializeField] private float maxSpeed = 20f;           // Maximum speed to limit the increase

    [Header("Obstacle Spawning")]
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private List<GameObject> pickups;
    [SerializeField] private float baseTime = 2f;
    [SerializeField] private float obstacleTimer = 2f;
    [SerializeField] private float randomVariation;

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

        // obstacle spawning
        if (obstacleTimer > 0)
        {
            obstacleTimer -= Time.deltaTime;
        }
        else
        {
            obstacleTimer = baseTime + Random.Range(-randomVariation, randomVariation);
            Obstacle obs = Instantiate(obstacles[Random.Range(0, obstacles.Count)].gameObject).GetComponent<Obstacle>();
            obs.transform.position = new Vector3(10, -1 + obs.YOffset, 0);
        }

        //Debug.Log("Current Speed: " + stats.GameSpeed);
    }
}
