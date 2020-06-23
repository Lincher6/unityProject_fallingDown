using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            UIManager.instance.scoreUpdate(10);
            Destroy(gameObject);
        }
    }
}
