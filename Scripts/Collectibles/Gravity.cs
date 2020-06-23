using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private bool isLow;
    [SerializeField]
    private GameObject parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isLow)
            {
                PowerUps.instance.LowGravity(true);
            }
            else
            {
                PowerUps.instance.LowGravity(false);
            }

            Destroy(parent);
        }
    }
}
