using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;
    private Animator animator;

    private int animationState = 0; // 0 is idle, 1 is running, 2 is jumping

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D> ();
        animator = GetComponentInChildren<Animator> ();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && rb.linearVelocityY == 0) // only jump if grounded
        {
            rb.AddForceY(jumpForce * 100);
        }


        // update animation
        if (rb.linearVelocityY == 0)
            SetRunning();
        else if (rb.linearVelocityY != 0)
            SetJumping();
    }

    // updates active animation based on animation state
    private void UpdateAnimation()
    {

    }

    // sets animation state to running
    public void SetRunning()
    {
        animationState = 1;
        animator.Play("run");
    }

    // sets animation state to jumping
    public void SetJumping()
    {
        animationState = 2;
        animator.Play("jumping");
    }

    // sets animation state to buried
    public void SetBuried()
    {
        animator.Play("root");
    }

    public void SetNotBurried()
    {
        animator.Play("uproot");
    }

    // sets animation state to idle
    public void SetIdle()
    {
        animationState = 0;
        animator.Play("idle");
    }
}
