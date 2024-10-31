using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private int ammo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            GameStats.Ammo += ammo;
            Destroy(this.gameObject);
        }
    }
}
