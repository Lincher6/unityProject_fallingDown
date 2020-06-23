using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerFlies : MonoBehaviour
{
    private float speed = -5;
    private float minY = -10;

    void FixedUpdate()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.instance.PlayerDeath();
        }
    }
}
