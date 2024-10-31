using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameStats stats;

    [Header("Game Speed")]
    [SerializeField] private float baseSpeed = 2f;           // Initial speed of the game
    [SerializeField] private float speedIncreaseRate = 0.1f; // Rate at which the speed increases over time
    [SerializeField] private float maxSpeed = 20f;           // Maximum speed to limit the increase

    [Header("Obstacle Spawning")]
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private float baseTime = 2f;
    [SerializeField] private float obstacleTimer = 2f;
    [SerializeField] private float randomVariation;


    private void Awake()
    {
        stats.GameSpeed = baseSpeed;
    }

    private void Update()
    {
        // speed
        if (stats.GameSpeed < maxSpeed)
        {
            stats.GameSpeed += speedIncreaseRate * Time.deltaTime;
        }

        // obstacle spawning
        if (obstacleTimer > 0)
        {
            obstacleTimer -= Time.deltaTime;
        }
        else
        {
            obstacleTimer = baseTime + Random.Range(-randomVariation, randomVariation);
            var obs = Instantiate(obstacles[Random.Range(0, obstacles.Count)]);
            obs.transform.position = new Vector3(10, -1, 0);
        }

        //Debug.Log("Current Speed: " + stats.GameSpeed);
    }
}
