using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public Animator anim;
    [SerializeField]
    private ParticleSystem particle;

    void Awake()
    {
            anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.Play("Break");
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.3f);
    }

    void DeactivateGameObject()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
