using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float power = 0.5f;

    public bool movingLeft, movingRight;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (movingLeft)
            {
                collision.gameObject.GetComponent<PlayerMovement>().PlatformMove(-power);
            }
            else if (movingRight)
            {
                collision.gameObject.GetComponent<PlayerMovement>().PlatformMove(power);
            }
        }
    }
}
