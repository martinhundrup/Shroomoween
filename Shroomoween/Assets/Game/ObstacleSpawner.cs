using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Spawning")]
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private float baseTime = 2f;
    [SerializeField] private float obstacleTimer = 2f;
    [SerializeField] private float randomVariation;

    private void Update()
    {
        // obstacle spawning
        if (obstacleTimer > 0)
        {
            obstacleTimer -= Time.deltaTime;
        }
        else
        {
            obstacleTimer = baseTime + Random.Range(-randomVariation, randomVariation);
            Obstacle obs = Instantiate(obstacles[Random.Range(0, obstacles.Count)].gameObject).GetComponent<Obstacle>();
            obs.transform.position = transform.position + new Vector3(0f, obs.YOffset, 0f);
        }
    }
}
