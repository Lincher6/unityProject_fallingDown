using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDeath : MonoBehaviour
{
    [SerializeField]
    private GameObject fire;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.instance.PlayerDeath();
            Instantiate(fire, collision.gameObject.transform.position, Quaternion.identity);
        }
    }
}
