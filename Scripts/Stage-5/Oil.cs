using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private AudioSource audio;
    private PlayerMovement player;

    private void Start()
    {
        player = PlayerMovement.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audio.Play();
            anim.SetTrigger("land");
            player.SetSpeed(1);
            player.SetJumpForce(5);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player != null)
            {
                player.SetSpeed(player.GetInitialSpeed());
                player.SetJumpForce(player.GetInitialJumpForce());
            }
        }
    }
}
