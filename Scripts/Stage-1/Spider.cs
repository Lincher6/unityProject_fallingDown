using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem deathEffect;
    [SerializeField]
    private GameObject spiderWeb;

    private void Start()
    {
        StartCoroutine(WebShot());
    }

    private IEnumerator WebShot()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(3);
            if (!GameManager.instance.IsGameStopped())
            {
                Instantiate(spiderWeb, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(4);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.instance.LunchUp(7);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.tag == "Spikes")
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
