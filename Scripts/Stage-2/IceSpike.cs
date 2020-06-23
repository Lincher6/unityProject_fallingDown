using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!PlayerMovement.instance.IsShield())
            {
                PlayerMovement.instance.PlayerDeath();
            }
            else
            {
                PlayerMovement.instance.SetShield(false);
            }
        }
    }
}
