using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCookie : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject fire1;
    [SerializeField]
    private GameObject fire2;
    [SerializeField]
    private GameObject cookie;
    [SerializeField]
    private GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.instance.LunchUp(7);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Instantiate(cookie, fire1.gameObject.transform.position, Quaternion.identity);
            Instantiate(cookie, fire2.gameObject.transform.position, Quaternion.identity);
            Destroy(enemy.gameObject);
        }
    }
}
