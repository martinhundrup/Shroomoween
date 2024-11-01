using System.Collections;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        StartCoroutine(OnDeath());
    }

    IEnumerator OnDeath()
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(this.gameObject);
    }
}
