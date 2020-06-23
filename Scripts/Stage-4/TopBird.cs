using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBird : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(bird);
        }
    }
}
