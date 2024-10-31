using System.Collections;
using UnityEngine;

public class Enemy : Obstacle
{
    // kill the enemy if collides with bullet
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        GameStats.OnGameRestart += base.OnRestart;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Bullet"))
        {
            speedModifier = 0; // stop movement
            GetComponent<Collider2D>().enabled = false; // disable collider
            animator.Play("Death");
            StartCoroutine(OnDeath());
        }
    }

    IEnumerator OnDeath()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
    

}
