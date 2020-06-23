using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaterBalloon : MonoBehaviour
{
    [SerializeField]
    private GameObject water;
    [SerializeField]
    private GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.instance.LunchUp(7);
            Instantiate(water, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
