using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField]
    private float power = 0.5f;

    public bool movingLeft, movingRight;

    private PlayerMovement player;

    private void Start()
    {
        player = PlayerMovement.instance;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (movingLeft)
            {
                player.PlatformMove(-power);
            }
            else if (movingRight)
            {
                player.PlatformMove(power);
            }
        }
    }
}
