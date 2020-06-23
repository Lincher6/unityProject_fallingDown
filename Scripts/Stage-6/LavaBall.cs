using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBall : MonoBehaviour
{
    [SerializeField]
    private GameObject fire;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
    }

    private void Update()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.instance.PlayerDeath();
            Instantiate(fire, collision.gameObject.transform.position, Quaternion.identity);
        }
    }
}
