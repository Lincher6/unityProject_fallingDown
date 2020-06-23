using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopElectricity : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.instance.PlayerDeath();
        }
    }
}
