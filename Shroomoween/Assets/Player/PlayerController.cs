using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;
    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletCount;
    [SerializeField] private Animator spriteAnimator;  // child animator
    [SerializeField] private Animator parentAnimator; // parent animator

    private int animationState = 0; // 0 is idle, 1 is running, 2 is jumping

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void Update()
    {
        // TODO: refactor to allow jump button to be held
        if (Input.GetButtonDown("Jump") && rb.linearVelocityY == 0) // only jump if grounded
        {
            rb.AddForceY(jumpForce * 100);
        }

        // shooting
        if (Input.GetButtonDown("Fire") && GameStats.Ammo > 0)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                var obj = Instantiate(bullet);
                obj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
            }

            GameStats.Ammo--;
        }

        // update animation
        if (rb.linearVelocityY == 0)
            SetRunning();
        else if (rb.linearVelocityY != 0)
            SetJumping();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle"))
        {
            parentAnimator.Play("Death");
            GameStats.GameSpeed = 0;
        }

        if (collision.gameObject.CompareTag("Acorn"))
        {
            Destroy(collision.gameObject);
            GameStats.Ammo++;

        }
    }

    // updates active animation based on animation state
    private void UpdateAnimation()
    {

    }

    // sets animation state to running
    public void SetRunning()
    {
        animationState = 1;
        spriteAnimator.Play("run");
    }

    // sets animation state to jumping
    public void SetJumping()
    {
        animationState = 2;
        spriteAnimator.Play("jumping");
    }

    // sets animation state to buried
    public void SetBuried()
    {
        spriteAnimator.Play("root");
    }

    public void SetNotBurried()
    {
        spriteAnimator.Play("uproot");
    }

    // sets animation state to idle
    public void SetIdle()
    {
        animationState = 0;
        spriteAnimator.Play("idle");
    }
}
