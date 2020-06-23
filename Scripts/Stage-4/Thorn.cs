using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerMovement.instance.IsShield())
            {
                PlayerMovement.instance.SetShield(false);
            }
            else
            {
                PlayerMovement.instance.PlayerDeath();
            }
        }
    }
}
