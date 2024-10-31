using UnityEngine;

// moves objects to the left depening on the game speed
[RequireComponent(typeof(Rigidbody2D))]
[System.Serializable]
public class TilemapBlock : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocityX = -GameStats.GameSpeed;


        // delete itself if it goes off screen
        if (transform.position.x < -5)
        {
            Debug.Log(transform.position.x);

            // rather than destroy, we will reset position
            transform.position = new Vector3(15, transform.position.y, 0f);
        }
    }
}
