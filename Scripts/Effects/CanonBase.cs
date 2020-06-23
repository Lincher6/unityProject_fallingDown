using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBase : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject debris;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement.instance.LunchUp(7);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Instantiate(debris, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
