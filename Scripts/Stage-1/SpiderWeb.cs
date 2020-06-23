using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    private Vector3 moveVector;
    [SerializeField]
    private float speed = 2;
    private bool isHit = false;
    [SerializeField]
    private ParticleSystem effect;

    void Start()
    {
        moveVector = (PlayerMovement.instance.transform.position - transform.position).normalized;
        Invoke("Death", 10);
    }

    void Update()
    {
        if (!isHit)
        {
            transform.Translate(moveVector * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isHit)
        {
            PlayerMovement.instance.SlowDown(3, 2);
            isHit = true;
            Invoke("Death", 3);
            transform.position = PlayerMovement.instance.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.position = PlayerMovement.instance.transform.position;
        }
    }

    private void Death()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
