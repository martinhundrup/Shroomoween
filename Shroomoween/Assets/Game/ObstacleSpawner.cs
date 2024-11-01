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

        // don't update if game isn't running
        if (GameStats.GameSpeed <= 0)
            return;

        // obstacle spawning
        if (obstacleTimer > 0)
        {
            obstacleTimer -= Time.deltaTime;
        }
        else
        {
            // make it harder as the game speed gets higher


            obstacleTimer = baseTime + Random.Range(-randomVariation, randomVariation);
            obstacleTimer *= (100f - GameStats.GameSpeed) / 100f;
            Obstacle obs = Instantiate(obstacles[Random.Range(0, obstacles.Count)].gameObject, transform).GetComponent<Obstacle>();
            obs.transform.position = transform.position + new Vector3(0f, obs.YOffset, 0f);
        }
    }
}
