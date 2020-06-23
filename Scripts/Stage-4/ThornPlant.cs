using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornPlant : MonoBehaviour
{
    [SerializeField]
    private GameObject thorn;
    [SerializeField]
    private GameObject explosion;

    private float posY = -3.5f;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("explode");
        }
    }

    public void Explode()
    {
        Instantiate(thorn, transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(thorn, transform.position, Quaternion.Euler(0, 0, -35));
        Instantiate(thorn, transform.position, Quaternion.Euler(0, 0, 35));
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
