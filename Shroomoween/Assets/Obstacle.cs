using UnityEngine;

// moves objects to the left depening on the game speed
[RequireComponent (typeof(Rigidbody2D))]
[System.Serializable]
public class Obstacle : MonoBehaviour
{
    [SerializeField] protected float speedModifier = 1f;
    [SerializeField] private float yOffset = 0f;

    public float YOffset
    {
        get { return yOffset; }
    }

    protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GameStats.OnGameRestart += OnRestart;
    }

    private void Update()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        rb.linearVelocityX = -GameStats.GameSpeed * speedModifier;

       
        // delete itself if it goes off screen
        if (transform.position.x < -15)
        {
            Destroy(this.gameObject);
        }
    }

    protected void OnRestart()
    {
        GameStats.OnGameRestart -= OnRestart;
        Destroy(this.gameObject);
    }

    protected void OnDestroy()
    {
        GameStats.OnGameRestart -= OnRestart;
    }
}
