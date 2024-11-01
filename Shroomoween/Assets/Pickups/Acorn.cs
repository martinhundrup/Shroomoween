using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private int ammo;
    [SerializeField] private GameObject indicator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            GameStats.Ammo += ammo;
            var obj = Instantiate(indicator);
            obj.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }
}
