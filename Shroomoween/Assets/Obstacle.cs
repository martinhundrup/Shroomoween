using UnityEngine;

// moves objects to the left depening on the game speed
[RequireComponent (typeof(Rigidbody2D))]
[System.Serializable]
public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speedModifier = 1f;
    [SerializeField] private float yOffset = 0f;

    public float YOffset
    {
        get { return yOffset; }
    }

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocityX = -GameStats.GameSpeed * speedModifier;

       
        // delete itself if it goes off screen
        if (transform.position.x < -10)
        {
            Debug.Log(transform.position.x);
            Destroy(this.gameObject);
        }
    }
}
