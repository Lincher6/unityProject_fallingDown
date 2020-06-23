using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField]
    private GameObject deathEffect;
    [SerializeField]
    private GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerMovement.instance.IsShield())
            {
                PlayerMovement.instance.SetShield(false);
                PlayerMovement.instance.LunchUp(7);
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(enemy.gameObject);
            }
            else
            {
                PlayerMovement.instance.PlayerDeath();
            }
        }
    }
}
