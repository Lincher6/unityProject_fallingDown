using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    private float boundY = 6f;
    private float boundX = 6f;
    private float speed = 4f;
    [SerializeField]
    private GameObject hitEffect;

    private void Start()
    {
        StartCoroutine(BorderCheck());
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!PlayerMovement.instance.IsShield())
            {
                PlayerMovement.instance.Stun();
            }
            else
            {
                PlayerMovement.instance.SetShield(false);
            }

            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator BorderCheck()
    {
        if (transform.position.y > boundY ||
            transform.position.y < -boundY ||
            transform.position.x > boundX ||
            transform.position.x < -boundX)
        {
            Destroy(gameObject);
        }

        yield return new WaitForSeconds(1);
    }
}
