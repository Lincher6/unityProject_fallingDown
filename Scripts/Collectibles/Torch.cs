using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField]
    private GameObject father;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PowerUps.instance.Torch();
            Destroy(father.gameObject);
        }
    }
}
