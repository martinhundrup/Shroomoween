using System.Collections;
using UnityEngine;

public class Enemy : Obstacle
{
    // kill the enemy if collides with bullet
    private Animator animator;
    [SerializeField] private GameObject indicator;
    private bool isDead = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        GameStats.OnGameRestart += base.OnRestart;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && !isDead)
        {
            SFXManager.instance.PlayKill();
            isDead = true;
            speedModifier = 0; // stop movement
            GetComponent<Collider2D>().enabled = false; // disable collider
            animator.Play("Death");
            GameStats.Score += 100;
            var obj = Instantiate(indicator);
            obj.transform.position = this.transform.position;
            StartCoroutine(OnDeath());
        }
    }

    IEnumerator OnDeath()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
    

}
