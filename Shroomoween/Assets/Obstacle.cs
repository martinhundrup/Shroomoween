using UnityEngine;

// moves objects to the left depening on the game speed
[RequireComponent (typeof(Rigidbody2D))]
[System.Serializable]
public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speedModifier = 1f;
    [SerializeField] private GameStats gameStats;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocityX = -gameStats.GameSpeed * speedModifier;

       
        // delete itself if it goes off screen
        if (transform.position.x < -10)
        {
            Debug.Log(transform.position.x);
            Destroy(this.gameObject);
        }
    }
}
